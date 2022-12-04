using Interpreter;
using System;
using System.Collections.Generic;

namespace Sample2_Interpretet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd --  HH:mm:ss"));

            List<IAbstractExpression> abstractExpressions = new List<IAbstractExpression>();
            Context context = new Context(DateTime.Now);

            while (true)
            {
                Console.WriteLine("Please select the Expression  : MM DD YYYY or YYYY MM DD or DD MM YYYY  or DD MM YY ");
                context.expression = Console.ReadLine().ToUpper();
                string[] formats = context.expression.Split(' ');

                foreach (var item in formats)
                {
                    if (item == "YYYY")
                    {
                        abstractExpressions.Add(new YearExpression());
                    }
                    else if (item == "MM")
                    {
                        abstractExpressions.Add(new MonthExpression());
                    }
                    else if (item == "DD")
                    {
                        abstractExpressions.Add(new DayExpression());
                    }
                    else if (item == "YY")
                    {
                        abstractExpressions.Add(new YearShortExpression());
                    }
                }
                foreach (var item in abstractExpressions)
                {
                    item.Interpret(context);
                }

                Console.WriteLine(context.expression);

                Console.Read();
            }
        }
    }
}
