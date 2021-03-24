using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Konusarak_Ingilizce.Models
{
    public class Web_Packed
    {
        public Web_Packed(string Text_title,string Text_content)
        {
            this.Text_title=Text_title;
            this.Text_content=Text_content;

        }
        public string Text_title;
        public string Text_content;

    }
}
