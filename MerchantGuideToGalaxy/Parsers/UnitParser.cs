using MerchantGuideToGalaxy.Contexts;
using System;
using System.Linq;

namespace MerchantGuideToGalaxy.Parsers
{
    class UnitParser : Parsers.Parser
    {
        public UnitParser(Context ctx) : base(ctx)
        {
        }

        public override bool Parse(string input)
        {
            string[] lexers = input.Split(new[] { " is " }, StringSplitOptions.RemoveEmptyEntries);
            if (lexers.Count() != 2 || input.EndsWith("?"))
                return false;

            string[] left = lexers[0].Split(' ');

            if (left.Length < 2)
                return false;
            int rValue = int.Parse(lexers[1].Split(' ')[0]);
            string primUnit = lexers[1].Split(' ')[1];
            Context.PrimUnit = primUnit;


            Romans.Roman roman = Romans.Roman.Parse(String.Join(" ", left.Take(left.Length - 1)), Context.Primitives);
            int calculated = roman.Calculate();

            string unit = left.Last();
            double unitValue = rValue / (double)calculated;

            Context.Units[unit] = unitValue;
            return true;
        }
    }

}
