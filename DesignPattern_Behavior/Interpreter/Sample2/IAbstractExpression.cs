using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public interface IAbstractExpression
    {
        void Interpret(Context context);
    }

    // DD MM YYYY YY

    public class YearExpression : IAbstractExpression
    {
        public void Interpret(Context context)
        {
            string expression = context.expression;
            context.expression = expression.Replace("YYYY", context.date.Year.ToString());
        }
    }

    public class MonthExpression : IAbstractExpression
    {
        public void Interpret(Context context)
        {
            string expression = context.expression;
            context.expression = expression.Replace("MM", context.date.Month.ToString());
        }
    }

    public class DayExpression : IAbstractExpression
    {
        public void Interpret(Context context)
        {
            string expression = context.expression;
            context.expression = expression.Replace("DD", context.date.Day.ToString());
        }
    }

    public class YearShortExpression : IAbstractExpression
    {
        public void Interpret(Context context)
        {
            string expression = context.expression;
            context.expression = expression.Replace("YY", context.date.Year.ToString().Substring(2, 2));

        }
    }

    class SeparatorExpression : IAbstractExpression
    {
        public void Interpret(Context context)
        {
            string expression = context.expression;
            context.expression = expression.Replace(" ", "-");
        }
    }
}
