using Baltazar.ContentContext.Enums;
using Baltazar.SharedContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baltazar.ContentContext
{
    public class Lessons : Base
    {
        public string Title { get; set; }
        public int Order { get; set; }

        public int DurationInMinutes { get; set; }

        public EContentLevel Level { get; set; }
    }
}
