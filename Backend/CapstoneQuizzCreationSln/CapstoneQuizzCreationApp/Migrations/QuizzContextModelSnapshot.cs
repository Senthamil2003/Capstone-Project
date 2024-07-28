﻿// <auto-generated />
using System;
using CapstoneQuizzCreationApp.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CapstoneQuizzCreationApp.Migrations
{
    [DbContext(typeof(QuizzContext))]
    partial class QuizzContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CapstoneQuizzCreationApp.Models.Certificate", b =>
                {
                    b.Property<int>("CertificateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CertificateId"), 1L, 1);

                    b.Property<int>("MaxObtainedScore")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProvidedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubmissionId")
                        .HasColumnType("int");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.Property<double>("TimeTaken")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CertificateId");

                    b.HasIndex("SubmissionId");

                    b.HasIndex("TestId");

                    b.HasIndex("UserId");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("CapstoneQuizzCreationApp.Models.CertificationTest", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestId"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<double>("PassCount")
                        .HasColumnType("float");

                    b.Property<int>("QuestionNeedTotake")
                        .HasColumnType("int");

                    b.Property<int>("RetakeWaitDays")
                        .HasColumnType("int");

                    b.Property<string>("TestDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TestDurationMinutes")
                        .HasColumnType("int");

                    b.Property<string>("TestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TestTakenCount")
                        .HasColumnType("float");

                    b.Property<int>("TotalQuestionCount")
                        .HasColumnType("int");

                    b.HasKey("TestId");

                    b.ToTable("CertificationTests");
                });

            modelBuilder.Entity("CapstoneQuizzCreationApp.Models.Favourite", b =>
                {
                    b.Property<int>("FavouriteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FavouriteId"), 1L, 1);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("UsserId")
                        .HasColumnType("int");

                    b.HasKey("FavouriteId");

                    b.HasIndex("TestId");

                    b.HasIndex("UserId");

                    b.ToTable("Favourites");
                });

            modelBuilder.Entity("CapstoneQuizzCreationApp.Models.Option", b =>
                {
                    b.Property<int>("OptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OptionId"), 1L, 1);

                    b.Property<string>("OptionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("OptionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("CapstoneQuizzCreationApp.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionId"), 1L, 1);

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("QuestionDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.HasKey("QuestionId");

                    b.HasIndex("TestId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("CapstoneQuizzCreationApp.Models.Submission", b =>
                {
                    b.Property<int>("SubmissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubmissionId"), 1L, 1);

                    b.Property<bool>("IsPassed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSubmited")
                        .HasColumnType("bit");

                    b.Property<int>("ObtainedScore")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SubmissionTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.Property<double>("TimeTaken")
                        .HasColumnType("float");

                    b.Property<int>("TotalScore")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SubmissionId");

                    b.HasIndex("TestId");

                    b.HasIndex("UserId");

                    b.ToTable("Submissions");
                });

            modelBuilder.Entity("CapstoneQuizzCreationApp.Models.SubmissionAnswer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnswerId"), 1L, 1);

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMarked")
                        .HasColumnType("bit");

                    b.Property<string>("Option")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("SubmissionId")
                        .HasColumnType("int");

                    b.HasKey("AnswerId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SubmissionId");

                    b.ToTable("SubmissionAnswers");
                });

            modelBuilder.Entity("CapstoneQuizzCreationApp.Models.TestHistory", b =>
                {
                    b.Property<int>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HistoryId"), 1L, 1);

                    b.Property<int?>("CertificateId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPassed")
                        .HasColumnType("bit");

                    b.Property<int>("LatestSubmissionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LatesttestEndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxObtainedScore")
                        .HasColumnType("int");

                    b.Property<int?>("PassSubmissionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SubmissionTIme")
                        .HasColumnType("datetime2");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.Property<double?>("TimeTaken")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("HistoryId");

                    b.HasIndex("CertificateId");

                    b.HasIndex("LatestSubmissionId");

                    b.HasIndex("TestId");

                    b.HasIndex("UserId");

                    b.ToTable("TestHistories");
                });

            modelBuilder.Entity("CapstoneQuizzCreationApp.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSubcribed")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CapstoneQuizzCreationApp.Models.UserCredential", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("HasedPassword")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Email");

                    b.HasIndex("UserId");

                    b.ToTable("UserCredential");
                });

            modelBuilder.Entity("CapstoneQuizzCreationApp.Models.Certificate", b =>
                {
                    b.HasOne("CapstoneQuizzCreationApp.Models.Submission", "Submission")
                        .WithMany()
                        .HasForeignKey("SubmissionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CapstoneQuizzCreationApp.Models.CertificationTest", "CertificationTest")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CapstoneQuizzCreationApp.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CertificationTest");

                    b.Navigation("Submission");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CapstoneQuizzCreationApp.Models.Favourite", b =>
                {
                    b.HasOne("CapstoneQuizzCreationApp.Models.CertificationTest", "CertificationTest")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CapstoneQuizzCreationApp.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CertificationTest");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CapstoneQuizzCreationApp.Models.Option", b =>
                {
                    b.HasOne("CapstoneQuizzCreationApp.Models.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("CapstoneQuizzCreationApp.Models.Question", b =>
                {
                    b.HasOne("CapstoneQuizzCreationApp.Models.CertificationTest", "CertificationTest")
                        .WithMany("Questions")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CertificationTest");
                });

            modelBuilder.Entity("CapstoneQuizzCreationApp.Models.Submission", b =>
                {
                    b.HasOne("CapstoneQuizzCreationApp.Models.CertificationTest", "CertificationTest")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CapstoneQuizzCreationApp.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CertificationTest");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CapstoneQuizzCreationApp.Models.SubmissionAnswer", b =>
                {
                    b.HasOne("CapstoneQuizzCreationApp.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CapstoneQuizzCreationApp.Models.Submission", "Submission")
                        .WithMany("SubmissionAnswers")
                        .HasForeignKey("SubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("Submission");
                });

            modelBuilder.Entity("CapstoneQuizzCreationApp.Models.TestHistory", b =>
                {
                    b.HasOne("CapstoneQuizzCreationApp.Models.Certificate", "Certificate")
                        .WithMany()
                        .HasForeignKey("CertificateId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CapstoneQuizzCreationApp.Models.Submission", "Submission")
                        .WithMany()
                        .HasForeignKey("LatestSubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CapstoneQuizzCreationApp.Models.CertificationTest", "CertificationTest")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CapstoneQuizzCreationApp.Models.User", "User")
                        .WithMany("TestHistories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Certificate");

                    b.Navigation("CertificationTest");

                    b.Navigation("Submission");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CapstoneQuizzCreationApp.Models.UserCredential", b =>
                {
                    b.HasOne("CapstoneQuizzCreationApp.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CapstoneQuizzCreationApp.Models.CertificationTest", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("CapstoneQuizzCreationApp.Models.Question", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("CapstoneQuizzCreationApp.Models.Submission", b =>
                {
                    b.Navigation("SubmissionAnswers");
                });

            modelBuilder.Entity("CapstoneQuizzCreationApp.Models.User", b =>
                {
                    b.Navigation("TestHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
