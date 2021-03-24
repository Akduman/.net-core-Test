using HtmlAgilityPack;
using Konusarak_Ingilizce.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Konusarak_Ingilizce.Controllers
{
    public class AdminController : Controller
    {
        public static Admin admin_auth;
  


        public async Task<IActionResult> Login(Admin admin)
         {
               var context = new AppDbContext();
               var user = context.Admins.FirstOrDefault(x=>x.User_Name==admin.User_Name && x.Password==admin.Password);
              
               if (user!=null)
               {
                   var claims = new List<Claim>
                   {
                       new Claim(ClaimTypes.Name,admin.User_Name)
                   };
                   var useridentity = new ClaimsIdentity(claims, "Login");
                   ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                   await HttpContext.SignInAsync(principal);
                   admin_auth = user;
                   return RedirectToAction("List_Exam", "Admin");
               }
               return View();
         }
        [HttpGet]
        public IActionResult Login()
        {
            if (admin_auth!=null)
            {
                return RedirectToAction("List_Exam", "Admin");
            }
            return View();
        }

   
        [Authorize]
        public IActionResult List_Exam()
        {
           
            var context = new AppDbContext();
            var result= context.Exams.Include(b => b.Admin).Where(x=> x.Admin.AdminId==admin_auth.AdminId).ToList();
            ViewBag.exams = result;
            ViewBag.user = admin_auth;
            ViewBag.sessions = HttpContext.Session.GetString("IsExamCreate");
            return View();
        }

        //[Authorize]

        public IActionResult Create_exam()
        {
            List<Web_Packed> list_of_praf = new List<Web_Packed>();
            var context = new AppDbContext();
            var result = context.WebSites.ToList();
            foreach (var item in result)
            {
            
                var url = item.Url;
                var web = new HtmlWeb();
                var doc = web.Load(item.Url);

                var text_title = doc.DocumentNode.SelectSingleNode(item.xTitle).InnerHtml.ToString();
                var link = doc.DocumentNode.SelectSingleNode(item.xLink).Attributes["href"].Value;

                var new_url = url + link;
                var new_doc = web.Load(new_url);
                var text_content = new_doc.DocumentNode.SelectSingleNode(item.xContent).InnerHtml.ToString();
                text_content = Regex.Replace(text_content, @"<(.|\n)*?>", string.Empty);
                Web_Packed packed = new Web_Packed(text_title, text_content);

                list_of_praf.Add(packed);
            }         
            ViewBag.list_of_praf = list_of_praf;
            return View();
        }


        public IActionResult Create_exam2(Exam exam, IFormCollection _questions)
        {
            var context = new AppDbContext();
            var admin = context.Admins.Include(b => b.Exams).Where(x=>x.AdminId==admin_auth.AdminId).FirstOrDefault();
            IList<Question> questions = new List<Question>();
            for (int i = 0; i <= 3; i++)
            {
               questions.Add(new Question { Quest = _questions["Quest"][i], Answer = _questions["Answer"][i], Option_a = _questions["Option_a"][i], Option_b = _questions["Option_b"][i], Option_c = _questions["Option_c"][i], Option_d = _questions["Option_a"][i]});              
            }
            admin.Exams.Add(exam);
            context.SaveChanges();
            exam = context.Exams.Include(i => i.Questions).Where(s => s.ExamId == exam.ExamId).FirstOrDefault();
            exam.Questions.AddRange(questions);
            HttpContext.Session.SetString("IsExamCreate", "true");
            context.SaveChanges();
            return RedirectToAction("List_Exam", "Admin");
        }

        [HttpDelete]
        [Authorize]        
        public IActionResult Remove_exam(int Id)
        {
            try
            {
                var context = new AppDbContext();
                var exam = context.Exams.Include(e => e.Questions).Include(a=>a.Admin).Where(x => x.ExamId == Id && admin_auth.AdminId== x.Admin.AdminId).FirstOrDefault();
                foreach (var question in exam.Questions)
                {
                    context.Remove(question);
                }
                context.SaveChanges();
                exam = context.Exams.Find(Id);
                context.Remove(exam);
                context.SaveChanges();

            }
            catch (Exception)
            {
                return Forbid("You shall not pass! Yetersiz yetki hatası");
            }
            return Ok(true);
        }

    }
}
