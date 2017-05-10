using MerchantGuideToGalaxy.Contexts;

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
