using MerchantGuideToGalaxy.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGuideToGalaxy.Solvers
{
    internal abstract class Solver
    {
        public Solver(Context ctx)
        {
            Context = ctx;
        }

        public Context Context { get; private set; }

        public abstract bool Solve(string input, out string answer);
    }
}
