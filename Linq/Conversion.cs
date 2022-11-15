using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Conversion
{
    public class Conversion
    {
        static void Method()
        {

            Student[] studentArray =
            {
                 new Student { Name = "Ehsan"},
                 new Student { Name = "Milad"},
                 new Student { Name = "Hassan"},
                 new Student { Name = "Ahmad"},
            };

            var enumerable = studentArray.AsEnumerable();
            var queryable = studentArray.AsQueryable();

            var newEnumarable = studentArray.Cast<Student>();

            var arrayTest = enumerable.ToArray();

            arrayTest.ToList();

            //---------------------

            List<Student> students = new List<Student>()
            {
                 new Student    { Id= 1 , Name="Roshan"},
                 new Student    { Id= 2 , Name="Maryam"},
                 new Student    { Id= 3 , Name="Arezooo"},
                 new Student    { Id= 4 , Name="Samira"},
            };

            IDictionary<int, Student> keyValues = students.ToDictionary<Student, int>(s => s.Id);


            foreach (var key in keyValues.Keys)
                Console.WriteLine("Key: {0}, Value: {1}",
                                            key, (keyValues[key] as Student).Name);



            Console.ReadLine();
        }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
