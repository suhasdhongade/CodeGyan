using MerchantGuideToGalaxy.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGuideToGalaxy.Solvers
{
    internal class UnitSolver : Solver
    {
        public UnitSolver(Context ctx) : base(ctx)
        {
        }

        public override bool Solve(string question, out string answer)
        {
            string primUnit = Context.PrimUnit;
            string qualifier = String.Format("how many {0} is", primUnit);
            if (!question.StartsWith(qualifier))
            {
                answer = null;
                return false;
            }
            string body = question.Substring(qualifier.Length + 1);
            string[] lexers = body.Split(' ');
            string unit = lexers.Last().Trim();
            double unitValue = Context.Units[unit];
            int value = Romans.Roman.Parse(String.Join(" ", lexers.Take(lexers.Length - 1)), Context.Primitives).Calculate();
            answer = value * unitValue + " " + primUnit;
            Console.WriteLine(body + " is " + answer);
            return true;
        }
    }
}
