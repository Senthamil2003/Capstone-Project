using CapstoneQuizzCreationApp.CustomException;
using CapstoneQuizzCreationApp.Interfaces;
using CapstoneQuizzCreationApp.Models;
using CapstoneQuizzCreationApp.Models.DTO.RequestDTO;
using CapstoneQuizzCreationApp.Models.DTO.ResponseDTO;
using CapstoneQuizzCreationApp.Repositories.JoinedRepository;
using System;
using System.ComponentModel;

namespace CapstoneQuizzCreationApp.Services
{
    public class TestService:ITestService
    {
        private readonly IRepository<int, Question> _questionRepo;
        private readonly IRepository<int,Option> _optionRepo;
        private readonly IRepository<int, Certificate> _certificateRepo;
        private readonly IRepository<int, Submission> _submissionRepo;
        private readonly IRepository<int,SubmissionAnswer> _submissionAnswerRepo;
        private readonly CertificationTestQuestionRepository _certificationTestQuestionRepo;
        private readonly ITransactionService _transactionService;
        public readonly IRepository<int, CertificationTest> _certificateTestRepo;
        private readonly UserTestHIstory _userTestHIstory;
        private readonly IRepository<int,TestHistory> _testHistoryRepo;
        private readonly SubmissionAnswerQuestionOnly _submissionAnswerQuestionOnly;
        private readonly SubmissionTestQuestionRepository _submissionQuestionRepo;
        public TestService(IRepository<int, Question> questionRepo,
            IRepository<int, Option> optionRepo,
            IRepository<int, Submission> submissionRepo,
            IRepository<int, SubmissionAnswer> submissionAnswerRepo,
            CertificationTestQuestionRepository certificationTestQuestionRepo,
            ITransactionService transactionService,
            UserTestHIstory userTestHIstory,
            IRepository<int, TestHistory> testHistoryRepo,
            SubmissionTestQuestionRepository submissionQuestionRepo,
            SubmissionAnswerQuestionOnly submissionAnswerQuestionOnly,
            IRepository<int, Certificate> certificateRepo,
            IRepository<int, CertificationTest> certificateTestRepo)
        {
            _questionRepo = questionRepo;
            _optionRepo = optionRepo;
            _submissionRepo = submissionRepo;
            _submissionAnswerRepo = submissionAnswerRepo;
            _certificationTestQuestionRepo = certificationTestQuestionRepo;
            _transactionService = transactionService;
            _userTestHIstory = userTestHIstory;
            _testHistoryRepo = testHistoryRepo;
            _submissionQuestionRepo = submissionQuestionRepo;
            _submissionAnswerQuestionOnly = submissionAnswerQuestionOnly;
            _certificateRepo = certificateRepo;
            _certificateTestRepo = certificateTestRepo;
        }
        public async Task<QuestionWithExpiryDate> StartTest(int certificationTestId, int UserId)
        {
            using (var transaction = await _transactionService.BeginTransactionAsync())
            {
                try
                {
                    TestHistory history = (await _userTestHIstory.Get(UserId)).TestHistories.FirstOrDefault(h => h.TestId == certificationTestId);

                    var test = (await _certificationTestQuestionRepo.Get(certificationTestId));
                    Random random = new Random();
                    var allquestions = test.Questions;
                    var questions = allquestions.OrderBy(q => random.Next()).Take(10);
                    DateTime now = DateTime.Now;
                    DateTime testEndTime = now.AddMinutes(test.TestDurationMinutes);
                    Submission submission = new Submission()
                    {
                        SubmissionTime = testEndTime,
                        TestId = certificationTestId,
                        TimeTaken = 0,
                        TotalScore = 0,
                        UserId = UserId,
                        StartTime=DateTime.Now, 

                    };
                    await _submissionRepo.Add(submission);
                    if (history != null)
                    {
                        DateTime retakedate = history.LatesttestEndTime.AddDays(test.RetakeWaitDays);
                        if (DateTime.Now < retakedate)
                        {
                            throw new Exception("User already taken please wait till waiting time");
                        }
                        else
                        {
                            history.LatesttestEndTime = DateTime.Now.AddMinutes(test.TestDurationMinutes);
                            history.LastSubmissionId = submission.SubmissionId;
                            await _testHistoryRepo.Update(history);
                        }
                    }
                    else
                    {
                        TestHistory testHistory = new TestHistory()
                        {
                            UserId = UserId,
                            TestId = certificationTestId,
                            LastSubmissionId = submission.SubmissionId,
                            LatesttestEndTime = testEndTime

                        };
                        await _testHistoryRepo.Add(testHistory);
                    }
                    List<TestQuestionDTO> questionDTOs = new List<TestQuestionDTO>();
                    foreach (var question in questions)
                    {

                        SubmissionAnswer submissionAnswer = new SubmissionAnswer()
                        {
                            IsMarked = false,
                            SubmissionId = submission.SubmissionId,
                            QuestionId = question.QuestionId,
                            IsCorrect = false,
                            
                        };
                        await _submissionAnswerRepo.Add(submissionAnswer);
                        List<OptionDTO> optionDTOs = new List<OptionDTO>();
                        foreach (var option in question.Options)
                        {
                            OptionDTO optionDTO = new OptionDTO()
                            {
                                OptionId = option.OptionId,
                                OptionName = option.OptionName,
                            };
                            optionDTOs.Add(optionDTO);
                        }
                        TestQuestionDTO testQuestionDTO = new TestQuestionDTO()
                        {
                            QuestionDescription = question.QuestionDescription,
                            QuestionId = question.QuestionId,
                            SubmissionAnswerId = submissionAnswer.AnswerId,
                            Options = optionDTOs,
                            QuestionType = question.QuestionType,

                        };
                        questionDTOs.Add(testQuestionDTO);

                    }

                    await _transactionService.CommitTransactionAsync();
                    QuestionWithExpiryDate questionWithExpiryDate = new QuestionWithExpiryDate()
                    {
                        TestEndTime = submission.SubmissionTime,
                        testQuestion = questionDTOs
                    };
                    return questionWithExpiryDate; 


                }
                catch
                {
                   await _transactionService.RollbackTransactionAsync();
                    throw;
                }
 

            }

        }
        public async Task<QuestionWithExpiryDate> ResumeTest(int SubmissionId, int userId )
        {
            try
            {
                Submission submission = (await _submissionQuestionRepo.Get(SubmissionId));
                if(submission.UserId != userId)
                {
                    throw new Exception("Submission not found for user");
                }
                if(submission.SubmissionTime< DateTime.Now)
                {
                    throw new Exception("Test is expired");
                }
                var questions = submission.SubmissionAnswers;

                List<TestQuestionDTO> questionDTOs = new List<TestQuestionDTO>();
                foreach (var question in questions)
                {
                    

                    List<OptionDTO> optionDTOs = new List<OptionDTO>();
                    foreach (var option in question.Question.Options)
                    {
                        OptionDTO optionDTO = new OptionDTO()
                        {
                            OptionId = option.OptionId,
                            OptionName = option.OptionName,
                        };
                        optionDTOs.Add(optionDTO);
                    }
                    TestQuestionDTO testQuestionDTO = new TestQuestionDTO()
                    {
                        QuestionDescription = question.Question.QuestionDescription,
                        QuestionId = question.QuestionId,
                        SubmissionAnswerId = question.AnswerId,
                        Options = optionDTOs,
                        QuestionType= question.Question.QuestionType,
                        SelectedAnswer=question.Option,
                        
                    };
                    questionDTOs.Add(testQuestionDTO);

                }
                return new QuestionWithExpiryDate
                {
                    TestEndTime = submission.SubmissionTime,
                    testQuestion = questionDTOs
                };


            }
            catch
            {
               
                throw;
            }
        }
        public async Task<SuccessSynchronieDTO> SynchronizeDb(List<SynchronousDataDTO> answers) 
        {
            using (var transaction = await _transactionService.BeginTransactionAsync())
            {
                try
                {
                    foreach(var answer in answers)
                    {
                        SubmissionAnswer newAnswer = await _submissionAnswerRepo.Get(answer.AnswerId);
                        newAnswer.Option=answer.AnswerName;
                        newAnswer.IsMarked=answer.IsFlaged;
                        await _submissionAnswerRepo.Update(newAnswer);
                    }
                    await _transactionService.CommitTransactionAsync();
                    return new SuccessSynchronieDTO()
                    {
                        Code = 200,
                        Message = "Synchronization Sucess"

                    };



                }
                catch
                {
                    await _transactionService.RollbackTransactionAsync();
                    throw;

                }


            }


        }
        public async Task<TestResultDTO> SubmitAnswer(SubmissionAnswerDTO submissionAnswer)
        {
            using (var transaction = await _transactionService.BeginTransactionAsync())
            {
                try
                {

                 Submission submission=  (await _submissionAnswerQuestionOnly.Get(submissionAnswer.SubmissionId));
                    if (submission.UserId != submissionAnswer.UserId)
                    {
                        throw new SubmissionAnswerNotFoundException("No submission found for user");

                    }
                    int totalScore=0;
                    int certificateId =0;   
                    int obtainedScore = 0;
                    foreach(var answer in submission.SubmissionAnswers)
                    {
                        totalScore += answer.Question.Points;
                        if (answer.Option == answer.Question.CorrectAnswer)
                        {
                            obtainedScore += answer.Question.Points;
                        }
                    }
                    submission.TotalScore= obtainedScore;
                    TimeSpan timeDifference = DateTime.Now - submission.StartTime;
                    submission.TimeTaken = timeDifference.TotalSeconds;
                    await _submissionRepo.Update(submission);
                    TestHistory history= (await _userTestHIstory.Get(submissionAnswer.UserId)).TestHistories.FirstOrDefault(h=>h.TestId==submission.TestId);
                    bool ispassed = false;
                    int MaxObtainedScore=obtainedScore;
                    if ((obtainedScore / totalScore) * 100 > 60)
                    {
                        if (history.IsPassed)
                        {
                            ispassed = true;
                           Certificate certificate=await _certificateRepo.Get(history.CertificateId);
                           if(certificate.MaxObtainedScore < obtainedScore)
                            {
                                certificate.MaxObtainedScore= obtainedScore;
                                history.MaxObtainedScore = obtainedScore;
                            }
                           certificateId=certificate.CertificateId;
                           MaxObtainedScore=certificate.MaxObtainedScore;
                           certificate.ProvidedDate= DateTime.Now;  
                           await _certificateRepo.Update(certificate);
                            
                        }
                        else
                        {

                            Certificate certificate = new Certificate()
                            {
                                ProvidedDate = DateTime.Now,
                                SubmissionId = submission.SubmissionId,
                                TestId = submission.TestId,
                                UserId = submission.UserId,
                            };
                            await _certificateRepo.Add(certificate);
                            history.IsPassed = true;
                            history.CertificateId=certificate.CertificateId;
                            history.MaxObtainedScore=certificate.MaxObtainedScore;
                            certificateId=certificate.CertificateId;

                        }
                      
                        await _testHistoryRepo.Update(history);
                                            

                    }
                    TestResultDTO resultDTO = new TestResultDTO()
                    {
                        IsPassed = ispassed,
                        ObtainedScore = obtainedScore,
                        TotalScore = totalScore,
                        TestName= (await _certificateTestRepo.Get(submission.TestId)).TestName,
                        MaxObtainedScore = MaxObtainedScore,
                        CertificateId=certificateId,

                    };

                    
                    await _transactionService.CommitTransactionAsync();


                    return resultDTO;


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
