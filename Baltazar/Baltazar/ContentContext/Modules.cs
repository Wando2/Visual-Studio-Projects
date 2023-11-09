
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baltazar.SharedContext;

namespace Baltazar.ContentContext
{
    public class Modules : Base
    {
        public Modules(string title, int order)
        {
            Lessons = new List<Lessons>();
            Title = title;
            Order = order;

        }
        public string Title { get; set; }

        public int Order { get; set; }

        public IList<Lessons> Lessons { get; set; }
    }
}
