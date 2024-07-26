using CapstoneQuizzCreationApp.Context;
using CapstoneQuizzCreationApp.Interfaces;
using CapstoneQuizzCreationApp.Models;
using CapstoneQuizzCreationApp.Repositories.GeneralRepository;
using CapstoneQuizzCreationApp.Repositories.JoinedRepository;
using CapstoneQuizzCreationApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CapstoneQuizzCreationApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region Log4net
            builder.Services.AddLogging(l => l.AddLog4Net());
            #endregion
            #region JWT-Authentication-Injection
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey:JWT"])),
                    };
                });
            #endregion
            #region Context
            builder.Services.AddDbContext<QuizzContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
            );
            #endregion


            #region Repository
            builder.Services.AddScoped<IRepository<int, User>, UserRepository>();
            builder.Services.AddScoped<IRepository<int, Certificate>, CertificateRepository>();
            builder.Services.AddScoped<IRepository<int, Favourite>, FavouriteRepository>();
            builder.Services.AddScoped<IRepository<int, Option>, OptionRepository>();
            builder.Services.AddScoped<IRepository<int, Question>, QuestionRepository>();
            builder.Services.AddScoped<IRepository<int, TestHistory>, TestHistoryRepository>();
            builder.Services.AddScoped<IRepository<int, Submission>, SubmissionRepository>();
            builder.Services.AddScoped<IRepository<int, CertificationTest>, CertificationTestRepository>();
            builder.Services.AddScoped<IRepository<int, SubmissionAnswer>, SubmissionAnswerRepository>();
            builder.Services.AddScoped<IRepository<string, UserCredential>, UserCredentialRepository>();
            builder.Services.AddScoped<ITransactionService, TransactionRepository>();
            builder.Services.AddScoped<CertificationTestQuestionRepository, CertificationTestQuestionRepository>();
            builder.Services.AddScoped<SubmissionTestQuestionRepository, SubmissionTestQuestionRepository>();
            builder.Services.AddScoped<SubmissionAnswerQuestionOnly, SubmissionAnswerQuestionOnly>();
            builder.Services.AddScoped<UserTestHIstory, UserTestHIstory>();


            #endregion
            #region Service
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<ITestService, TestService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            #endregion
            #region CORS
            builder.Services.AddCors(opts =>
            {
                opts.AddPolicy("MyCors", options =>
                {
                    options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            #endregion

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("MyCors");

            app.MapControllers();

            app.Run();
        }
    }
}
