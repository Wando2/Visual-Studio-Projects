using Baltazar.ContentContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baltazar
{
   public class Career : Content
    {
        public Career(string title,string url) : base(title,url)
        {
            CarrerItems = new List<CareerItem>();
        }

        public IList<CareerItem> CarrerItems { get; set; }

        public int TotalCourses => CarrerItems.Count;
    }



}
