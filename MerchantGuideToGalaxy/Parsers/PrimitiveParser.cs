using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantGuideToGalaxy.Contexts;
using MerchantGuideToGalaxy.Romans;

namespace MerchantGuideToGalaxy.Parsers
{
    internal class PrimitiveParser : Parsers.Parser
    {

        public PrimitiveParser(Context ctx) : base(ctx)
        {
        }

        public override bool Parse(string input)
        {
            string[] lexers = input.Split(new[] { " is " }, StringSplitOptions.RemoveEmptyEntries);
            if (lexers.Count() != 2)
                return false;
            if (lexers[1].Length > 1)
                return false;
            RomanPrimitive roman = RomanPrimitive.Parse(lexers[1][0]);
            if (roman == null)
            {
                throw new Exception("syntex error.");
            }
            string name = lexers[0].Trim();
            Context.Primitives[name] = roman;
            return true;
        }
    }
}
