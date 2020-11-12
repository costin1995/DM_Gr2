using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExtragereaTrasaturilor
{
   

    public class Article
    {
        public string title;
        public string text;
        List<string> ClassCodes = new List<string>();

        public Article(string t, string tex, List<string> ClassWithCodes)
        {
            title = t;
            text = tex;
            ClassCodes = ClassWithCodes;

        }


    }
}
