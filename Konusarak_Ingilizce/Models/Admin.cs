using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Konusarak_Ingilizce.Models
{
    public class Admin
    {

        public int AdminId { get; set; }
        public string Password { get; set; }
        public string User_Name { get; set; }

        public List<Exam> Exams { get; set; }
    }
}
