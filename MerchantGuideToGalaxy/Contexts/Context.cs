using System.Collections.Generic;
using MerchantGuideToGalaxy.Romans;

namespace MerchantGuideToGalaxy.Contexts
{
    internal class Context
    {
        public Context()
        {
            Primitives = new Dictionary<string, RomanPrimitive>();
            Units = new Dictionary<string, double>();
            Questions = new List<string>();
        }

        public string PrimUnit { get; set; }
        public Dictionary<string, RomanPrimitive> Primitives { get; set; }
        public Dictionary<string, double> Units { get; set; }
        public List<string> Questions { get; set; }
    }
}
