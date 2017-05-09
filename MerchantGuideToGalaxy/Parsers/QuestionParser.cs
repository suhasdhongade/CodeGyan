using MerchantGuideToGalaxy.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGuideToGalaxy.Parsers
{
    class QuestionParser : Parsers.Parser
    {
        public QuestionParser(Context ctx)
            : base(ctx)
        {
        }

        public override bool Parse(string input)
        {
            if (!input.EndsWith("?"))
                return false;
            Context.Questions.Add(input.Replace("?", "").Trim());
            return true;
        }
    }
}
