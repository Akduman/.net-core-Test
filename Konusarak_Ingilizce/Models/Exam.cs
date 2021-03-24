using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Konusarak_Ingilizce.Models
{
    public class Exam
    {
        public Exam()
        {
            if (Time==null)
            {
                Time = DateTime.Today;
            }

        }

        public int ExamId { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime? Time { get; set; }

        public Admin Admin { get; set; }
        public List<Question> Questions{get; set;} 






    }
}
