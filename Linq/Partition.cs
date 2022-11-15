using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Parttion
{
    public class Partition
    {
        static void Mehthod_Partition()
        {

            IList<int> data = new List<int>() { 5, 3, 6, 2, 4, 7, 8, 1 };

            var dataSkip = data.Skip(4);
            foreach (var item in dataSkip)
            {
                Console.Write(item + ",");
            }

            Console.WriteLine("");
            Console.WriteLine("__________________SkipWhile__________________");
            var dataSkipWhile = data.SkipWhile(p => p < 8);
            foreach (var item in dataSkipWhile)
            {
                Console.Write(item + ",");
            }

            Console.WriteLine("");
            Console.WriteLine("__________________Take__________________");
            var dataTake = data.Take(3);
            foreach (var item in dataTake)
            {
                Console.Write(item + ",");
            }


            Console.WriteLine("");
            Console.WriteLine("_________________TakeWhile________________");
            var dataTakeWhile = data.TakeWhile(p => p < 8);
            foreach (var item in dataTakeWhile)
            {
                Console.Write(item + ",");
            }


        }
    }
}
