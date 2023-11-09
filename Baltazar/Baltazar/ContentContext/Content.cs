using Baltazar.SharedContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baltazar
{
    public abstract class Content : Base
    {
     
        public string Title { get; set; }

        public string Url { get; set; }


        public Content(string title,string url)
        {
            Title = title;
            Url = url;
           
        }
    }
}
