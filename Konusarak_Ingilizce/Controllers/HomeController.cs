using Konusarak_Ingilizce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Konusarak_Ingilizce.Controllers
{
    public class HomeController : Controller
    {
 

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Exams()
        {
            var context = new AppDbContext();
            var exams = context.Exams.ToList();
            ViewBag.result = exams;
            return View();
        }
        [HttpGet]
        public  IActionResult Show(int id)
        {
            var context = new AppDbContext();
            var exam = context.Exams.Include(s => s.Questions).Where(x => x.ExamId == id).FirstOrDefault();
            ViewBag.exam = exam;
            return View();
        }
        
        [HttpGet]
        public IActionResult GetAnswer(int id)
        {
            var context = new AppDbContext();
            var answers = context.Questions.Where(x => x.Exam.ExamId == id).Select(x=>x.Answer).ToList();

            return Ok(answers);
           
        }



    }
}
