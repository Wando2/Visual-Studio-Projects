
using Baltazar.ContentContext.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baltazar.ContentContext;

public class Course : Content
{
    public Course(string title, string url) : base(title, url)
    {
        Modules = new List<Modules>();

    }
    public string Tag { get; set; }
    public IList<Modules> Modules { get; set; }

    public int DurationInMinutes { get; set; }

    public EContentLevel Level { get; set; }
}
