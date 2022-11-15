using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_More
{
    public class More
    {
        static void Method()
        {
            //Equality

            IList<int> data = new List<int>() { 5, 3, 10 };
            IList<int> data2 = new List<int>() { 5, 6, 10 };

            var result = data.SequenceEqual(data2);
            Console.WriteLine(result);

            //If Calss Equality

        //public class userComparer : IEqualityComparer<User>
        //{
        //    public bool Equals([AllowNull] User x, [AllowNull] User y)
        //    {
        //        if (x.Name == y.Name)
        //            return true;

        //        return false;
        //    }

        //    public int GetHashCode([DisallowNull] User obj)
        //    {
        //        return obj.Name.GetHashCode();
        //    }
        //}

        //----------------------------------------------------------

    }
    }
}
