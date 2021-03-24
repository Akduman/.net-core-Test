﻿// <auto-generated />
using System;
using Konusarak_Ingilizce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Konusarak_Ingilizce.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210123031014_test_v1")]
    partial class test_v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Konusarak_Ingilizce.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("User_Name")
                        .HasColumnType("TEXT");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            AdminId = 1,
                            Password = "123",
                            User_Name = "test_admin_name02"
                        },
                        new
                        {
                            AdminId = 2,
                            Password = "123",
                            User_Name = "test_admin_name19"
                        },
                        new
                        {
                            AdminId = 3,
                            Password = "123",
                            User_Name = "test_admin_name25"
                        });
                });

            modelBuilder.Entity("Konusarak_Ingilizce.Models.Exam", b =>
                {
                    b.Property<int>("ExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AdminId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Time")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("ExamId");

                    b.HasIndex("AdminId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("Konusarak_Ingilizce.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Answer")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ExamId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Option_a")
                        .HasColumnType("TEXT");

                    b.Property<string>("Option_b")
                        .HasColumnType("TEXT");

                    b.Property<string>("Option_c")
                        .HasColumnType("TEXT");

                    b.Property<string>("Option_d")
                        .HasColumnType("TEXT");

                    b.Property<string>("Quest")
                        .HasColumnType("TEXT");

                    b.HasKey("QuestionId");

                    b.HasIndex("ExamId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Konusarak_Ingilizce.Models.WebSite", b =>
                {
                    b.Property<int>("WebSiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.Property<string>("xContent")
                        .HasColumnType("TEXT");

                    b.Property<string>("xLink")
                        .HasColumnType("TEXT");

                    b.Property<string>("xTitle")
                        .HasColumnType("TEXT");

                    b.HasKey("WebSiteId");

                    b.ToTable("WebSites");
                });

            modelBuilder.Entity("Konusarak_Ingilizce.Models.test_model", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("test_name")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Test_models");

                    b.HasData(
                        new
                        {
                            id = 1,
                            test_name = "HR"
                        },
                        new
                        {
                            id = 2,
                            test_name = "Admin"
                        },
                        new
                        {
                            id = 3,
                            test_name = "Production"
                        });
                });

            modelBuilder.Entity("Konusarak_Ingilizce.Models.Exam", b =>
                {
                    b.HasOne("Konusarak_Ingilizce.Models.Admin", "Admin")
                        .WithMany("Exams")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("Konusarak_Ingilizce.Models.Question", b =>
                {
                    b.HasOne("Konusarak_Ingilizce.Models.Exam", "Exam")
                        .WithMany("Questions")
                        .HasForeignKey("ExamId");

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("Konusarak_Ingilizce.Models.Admin", b =>
                {
                    b.Navigation("Exams");
                });

            modelBuilder.Entity("Konusarak_Ingilizce.Models.Exam", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
