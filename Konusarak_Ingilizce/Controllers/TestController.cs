using Konusarak_Ingilizce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Konusarak_Ingilizce.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var context = new AppDbContext();

            var exam = context.Exams.Include(s=>s.Questions).Where(x => x.ExamId == 1).FirstOrDefault();
            ViewBag.exam = exam;
            return View();
            //return exam.Questions[0].Option_a;
        }

        public string Controller_test()
        {
            return "test index tset contoller";
        }



        public string Querry_add_test()
        {

            var context = new AppDbContext();            
            var admin = context.Admins.Include(b => b.Exams).First();
            var exam = new  Exam {Title = "Intro Intro Intro", Text= "Core Core Core"};
            var question = new Question {Quest="test quest" ,Answer = "a", Option_a = "options a", Option_b = "options a", Option_c = "options a", Option_d = "options a" };
            admin.Exams.Add(exam);                
            context.SaveChanges();         
            exam = context.Exams.Include(i=>i.Questions).Where(s => s.ExamId==exam.ExamId).FirstOrDefault();
            exam.Questions.Add(question);
            context.SaveChanges();
            return "Ok";
        }

        public string Querry_delete_test()
        {

            var context = new AppDbContext();
            var exam = context.Exams.Include(e => e.Questions).Where(x=>x.ExamId==7).FirstOrDefault();
            foreach (var question in exam.Questions)
            {
                context.Remove(question);
            }
            context.SaveChanges();

            return "Ok";

        }


        public IActionResult Querry_search_test()
            {

            /* 
                var context = new AppDbContext();
                var list_context = context.Exams.Include(x=>x.Admin).ToList();
                ViewBag.list_context = list_context;
            */
            var context = new AppDbContext();
            var list_context = context.Questions.Include(x => x.Exam).ToList();
            ViewBag.list_context = list_context;



            return View();

        }
     }
}
