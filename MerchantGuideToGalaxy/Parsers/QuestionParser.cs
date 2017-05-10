using MerchantGuideToGalaxy.Contexts;

namespace MerchantGuideToGalaxy.Parsers
{
    class QuestionParser : Parser
    {
        public QuestionParser(Context ctx) : base(ctx)
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
