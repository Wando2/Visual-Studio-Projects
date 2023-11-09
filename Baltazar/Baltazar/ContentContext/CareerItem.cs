using Baltazar.NotificationContext;
using Baltazar.SharedContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baltazar.ContentContext
{
    public class CareerItem : Base
    {
    public CareerItem(int order, string title, string description, Course course)
            {
                Order = order;
                Title = title;
                Description = description;

                if (course == null)
                    AddNotification(new Notification("Course", "Curso inválido"));
            
                Course = course;
            }
        public int Order { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Course Course { get; set; }



    }
}
