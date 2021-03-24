using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Konusarak_Ingilizce.Models;
using Microsoft.EntityFrameworkCore;

namespace Konusarak_Ingilizce.Models
{ 
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\zylo1\OneDrive\Masaüstü\SQLiteStudio\databases\test.db;");
        }


        ///////////Tables

        public DbSet<test_model> Test_models { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<WebSite> WebSites { get; set; }


        /// relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>()
               .HasOne(p => p.Admin)
               .WithMany(b => b.Exams)
               .OnDelete(DeleteBehavior.Cascade);


            var rand = new Random();
            modelBuilder.Entity<test_model>()
              .HasData(
              new test_model { id = 1, test_name = "HR" },
              new test_model { id = 2, test_name = "Admin" },
              new test_model { id = 3, test_name = "Production" });


            modelBuilder.Entity<Admin>()
              .HasData(
              new Admin { AdminId = 1, Password = "123", User_Name = "test_admin_name02"},
              new Admin { AdminId = 2, Password = "123", User_Name = "test_admin_name1" + rand.Next(0, 10).ToString(),},
              new Admin { AdminId = 3, Password = "123", User_Name = "test_admin_name2" + rand.Next(0, 10).ToString()});


            /*
                     modelBuilder.Entity<Exam>()
                       .HasData(
                       new Exam { ExamId = 1, Title = "test_title0", Text = "test_text0", Admin = { AdminId = 1 } },
                       new Exam { ExamId = 2,  Title = "test_title1", Text = "test_text1", Admin = { AdminId = 2} },
                       new Exam { ExamId = 3,  Title = "test_title2", Text = "test_text2", Admin = { AdminId = 3 } });

                     modelBuilder.Entity<Question>()
                      .HasData(
                      new Question { QuestionId = 1, Quest = "test quest0", Answer = "a", ExamId = 1 },
                      new Question { QuestionId = 2, Quest = "test quest1", Answer = "b", ExamId = 1 },
                      new Question { QuestionId = 3, Quest = "test quest2", Answer = "c", ExamId = 1 },
                      new Question { QuestionId = 5, Quest = "test quest3", Answer = "d" ,ExamId = 1 },

                      new Question { QuestionId = 7, Quest = "test quest0", Answer = "a", ExamId = 2 },
                      new Question { QuestionId = 8, Quest = "test quest1", Answer = "b", ExamId = 2 },
                      new Question { QuestionId = 9, Quest = "test quest2", Answer = "c", ExamId = 2 },
                      new Question { QuestionId = 10, Quest = "test quest3", Answer = "d", ExamId = 2 },


                      new Question { QuestionId = 11, Quest = "test quest0", Answer = "a" ,ExamId = 3 },
                      new Question { QuestionId = 12, Quest = "test quest1", Answer = "b", ExamId = 3 },
                      new Question { QuestionId = 13, Quest = "test quest2", Answer = "c", ExamId = 3 },
                      new Question { QuestionId = 15, Quest = "test quest3", Answer = "d" , ExamId = 3});

                     */




        }




        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<test_model>()
        //      .HasData(
        //       new test_model { id = 1, test_name = "HR" },
        //       new test_model { id = 2, test_name = "Admin" },
        //       new test_model { id = 3, test_name = "Production" });
        //}

    }
}
