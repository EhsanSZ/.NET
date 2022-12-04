using System;
using Strategy.Entities;
using System.Collections;
using System.Collections.Generic;

namespace DotNetStrategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var users = new User[]
           {
              new User { Id = 101 ,Credit=5000,Name="Ehsan" ,LastName="Seyedzadeh"},
              new User {Id = 105 ,Credit=8000,Name="Amir" ,LastName="Kharazi"},
              new User {Id = 109,Credit=3000, Name="Hamid" ,LastName="Jodeiry"},
           };

            Console.WriteLine("----------------Befor Sort------------");
            foreach (var item in users)
            {
                item.DisplayUser();
            }

            Array.Sort(users, new UserByCredit_Comparer());
            Console.WriteLine("----------------After Sort------------");
            foreach (var item in users)
            {
                item.DisplayUser();
            }



            Array.Sort(users, new UserById_Comparer());
            Console.WriteLine("----------------After Sort By Id------------");
            foreach (var item in users)
            {
                item.DisplayUser();
            }
        }
    }
    public class UserByCredit_Comparer : IComparer<User>
    {
        public int Compare(User x, User y)
        {
            if (x.Credit == y.Credit)
                return 0;
            else if (x.Credit > y.Credit)
                return 1;
            else
                return -1;
        }
    }


    public class UserById_Comparer : IComparer<User>
    {
        public int Compare(User x, User y)
        {
            if (x.Id == y.Id)
                return 0;
            else if (x.Id > y.Id)
                return 1;
            else
                return -1;
        }
    }
}
