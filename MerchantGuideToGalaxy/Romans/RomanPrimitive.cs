using System.Collections.Generic;
using System.Linq;

namespace MerchantGuideToGalaxy.Romans
{
    internal class RomanPrimitive
    {
        private static readonly ILookup<char, RomanPrimitive> Primitives = new List<RomanPrimitive>
        {
            new RomanPrimitive('I', 1, true, true),
            new RomanPrimitive('V', 5),
            new RomanPrimitive('X', 10, true, true),
            new RomanPrimitive('L', 50),
            new RomanPrimitive('C', 100, true, true),
            new RomanPrimitive('D', 500),
            new RomanPrimitive('M', 1000, true),
        }.ToLookup(_ => _.Symbol);

        public RomanPrimitive(char symbol, int octValue, bool allowRepeat = false, bool allowSubtract = false)
        {
            Symbol = symbol;
            OctValue = octValue;
            AllowRepeat = allowRepeat;
            AllowSubtract = allowSubtract;
        }

        public int OctValue { get; private set; }
        public char Symbol { get; private set; }
        public bool AllowRepeat { get; private set; }
        public bool AllowSubtract { get; private set; }

        public static RomanPrimitive Parse(char symbol)
        {
            if (!Primitives.Contains(symbol))
                return null;
            return Primitives[symbol].First();
        }
    }
}