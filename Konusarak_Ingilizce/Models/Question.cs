using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Konusarak_Ingilizce.Models
{
    public class Question
    {

        public int QuestionId { get; set; }

        public string Quest { get; set; } 
        public string Option_a { get; set; }
        public string Option_b { get; set; }
        public string Option_c { get; set; }
        public string Option_d { get; set; }
        
        public string Answer { get; set; }
        public Exam Exam { get; set; }
    }
}
