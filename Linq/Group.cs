using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Group
{
    public class Group
    {
        public static void Group_Example()
        {

            List<Team> teams = new List<Team>()
            {
                 new Team {  Name="Perpolis" , County = " Iran"},
                 new Team {  Name="Esteghlal" , County = " Iran"},
                 new Team {  Name="psg" , County = " France"},
                 new Team {  Name="Arsenal" , County = " England"},
                 new Team {  Name="Everton " , County = " England"},
                 new Team {  Name=" Manchester City " , County = " England"},
            };

            var result = teams.GroupBy(p => p.County);

            foreach (var country in result)
            {
                Console.WriteLine("County Group: {0}", country.Key);

                foreach (var item in country)
                {
                    Console.WriteLine("Team Name: {0}", item.Name);
                }
                Console.WriteLine("______________________");

            }

            var result2 = teams.ToLookup(p => p.County);

            foreach (var country in result2)
            {
                Console.WriteLine("County Group: {0}", country.Key);

                foreach (var item in country)
                {
                    Console.WriteLine("Team Name: {0}", item.Name);
                }
                Console.WriteLine("______________________");

            }

        }
    }
    public class Team
    {
        public string Name { get; set; }
        public string County { get; set; }
    }
}
