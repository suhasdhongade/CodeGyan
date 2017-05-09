using MerchantGuideToGalaxy.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGuideToGalaxy.Solvers
{
    class PrimitiveSolver : Solver
    {
        public PrimitiveSolver(Context ctx) : base(ctx)
        {
        }

        public override bool Solve(string question, out string answer)
        {
            string qualifier = "how much is";
            if (!question.StartsWith(qualifier))
            {
                answer = null;
                return false;
            }
            string body = question.Substring(qualifier.Length + 1);
            int value = Romans.Roman.Parse(body, Context.Primitives).Calculate();
            answer = value.ToString();
            Console.WriteLine(body + " is " + answer);
            return true;
        }
    }
}
