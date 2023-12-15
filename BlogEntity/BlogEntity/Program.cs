using blogEntity.Data;
using blogEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace blogEntity{

    public class Program{
        public static void Main(string[] args){
            using (var db = new BlogDataContext())
            {

                var tag = db.Tags.
                AsNoTracking().
                FirstOrDefault(x => x.Id == 1);

                System.Console.WriteLine(tag?.Name);
            }
              
        }
    }


}
