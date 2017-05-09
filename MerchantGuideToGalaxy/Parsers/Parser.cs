using MerchantGuideToGalaxy.Contexts;

namespace MerchantGuideToGalaxy.Parsers
{
    internal abstract class Parser
    {
        public Parser(Context ctx)
        {
            Context = ctx;
        }

        public Context Context { get; private set; }

        public abstract bool Parse(string input);
    }
}
