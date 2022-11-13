using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Filter
{
    public class Filter
    {
        public static void Filter_Sample()
        {

            var result = GetCourselist().Where((c, i) =>
             {

                 if (i % 2 == 0)
                     return true;

                 return false;
             }
            );

            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }

            IList list = new ArrayList();
            list.Add(100);
            list.Add("Bugeto.net");
            list.Add("babaei");
            list.Add("nader");
            list.Add(5);
            list.Add(new Course { Id = 1, Name = "test ", Price = 0 });

            var intResult = list.OfType<int>();
            var strResult = list.OfType<string>();

        }

        private static List<Course> GetCourselist()
        {
            List<Course> courses = new List<Course>()
            {
                 new Course { Id=1, Name="c-sharp" , Price= 10000},
                 new Course { Id=2, Name="Asp net core" , Price= 20000},
                 new Course { Id=3, Name="html" , Price= 5000},
                 new Course { Id=4, Name="css" , Price= 7000},
                 new Course { Id=5, Name="MongoDb" , Price= 55000},
                 new Course { Id = 6, Name = "Android", Price = 18000 }
            };

            return courses;
        }
    }
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}

