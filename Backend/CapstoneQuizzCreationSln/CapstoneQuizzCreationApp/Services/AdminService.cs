using CapstoneQuizzCreationApp.Interfaces;
using CapstoneQuizzCreationApp.Models;
using CapstoneQuizzCreationApp.Models.DTO.RequestDTO;
using CapstoneQuizzCreationApp.Models.DTO.ResponseDTO;

namespace CapstoneQuizzCreationApp.Services
{
    public class AdminService:IAdminService
    {
        private readonly IRepository<int,CertificationTest> _certificationRepo;
        private readonly IRepository<int,Question> _questionRepo;
        private readonly IRepository<int,Option> _optionRepo;
        private readonly ITransactionService _transactionService;
        public AdminService(
            IRepository<int, Option> optionRepo,
            IRepository<int,Question> questionRepo,
            IRepository<int,CertificationTest> certificationRepo,
            ITransactionService transactionService
            )
        {
            _optionRepo = optionRepo;
            _questionRepo = questionRepo;
            _certificationRepo = certificationRepo;
            _transactionService = transactionService;
        }
        private async Task CreateQuestion(List<QuestionDTO> questions,int CertificateTestId)
        {
            try
            {
                foreach (var questionItem in questions)
                {
                    Question question = new Question()
                    {
                        QuestionDescription = questionItem.Question,
                        Points = questionItem.points,
                        TestId = CertificateTestId,
                        QuestionType = questionItem.QuestionType,
                        IsActive = questionItem.IsActive,
                        CorrectAnswer=questionItem.CorrectAnswer,
                    };
                    await _questionRepo.Add(question);

                    foreach (var optionItem in questionItem.Options)
                    {

                        Option option = new Option()
                        {
                            OptionName = optionItem,
                            QuestionId = question.QuestionId,

                        };
                       await _optionRepo.Add(option);
                      
                    }
                    
                }

            }
            catch
            {
                throw;
            }



         }
        public async Task<SuccessCertificationTestCreatedDTO> CreateCertificationTest(CreateQuestionDTO createQuestion)
            {
            using (var transaction = await _transactionService.BeginTransactionAsync())
            {
                try
                {
                    CertificationTest certificationTest = new CertificationTest()
                    {
                        CreatedDate = DateTime.Now,
                        TotalQuestionCount = createQuestion.questions.Count,
                        QuestionNeedTotake = createQuestion.AttendQuestionCount,
                        RetakeWaitDays = createQuestion.RetakeWaitDays,
                        TestDescription = createQuestion.TestDescription,
                        TestDurationMinutes = createQuestion.TestDuration,
                        TestName = createQuestion.CertificationName,
                        TestTakenCount = 0,
                        IsActive = createQuestion.IsActive,
                        PassCount=0,
                        
                    };
                    await _certificationRepo.Add(certificationTest);
                    await CreateQuestion(createQuestion.questions, certificationTest.TestId);
                    await _transactionService.CommitTransactionAsync();
                    SuccessCertificationTestCreatedDTO successCertification = new SuccessCertificationTestCreatedDTO()
                    {
                        Message = "Certification Test Created Sucessfully",

                    };
                    return successCertification;
                    
                }
                catch
                {
                    await _transactionService.RollbackTransactionAsync();
                    throw;
                }

            }
        }
    }
}
