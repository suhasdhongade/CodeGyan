using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGuideToGalaxy.Romans
{
    class Roman
    {
        private readonly List<RomanPrimitive> _primitives;

        private bool _dirty = true;
        private int _valueCache;

        private Roman()
        {
            _primitives = new List<RomanPrimitive>();
        }

        public int Calculate()
        {
            if (_dirty)
            {
                _valueCache = 0;
                int result = 0;
                int length = _primitives.Count();
                for (int i = 0; i < length; i++)
                {
                    RomanPrimitive current = _primitives[i];
                    result += current.OctValue;

                    if (i == length - 1)
                        return result;

                    RomanPrimitive next = _primitives[i + 1];
                    if (current.OctValue < next.OctValue)
                    {
                        result = next.OctValue - result;
                        i++;
                    }
                    else if (current.OctValue == next.OctValue)
                    {
                        if (!current.AllowRepeat)
                        {
                            throw new Exception(string.Format("{0} can't be repeated", current.Symbol));
                        }
                        int count = 2;
                        for (int j = i + 2; j < length; j++)
                        {
                            if (_primitives[j].Symbol != current.Symbol)
                                break;
                            count++;
                            result += current.OctValue;
                            i++;
                            if (count > 3)
                            {
                                throw new Exception(string.Format("{0} can't be repeated more than 3 times",
                                    current.Symbol));
                            }
                        }
                    }
                }
                _valueCache = result;
            }

            return _valueCache;
        }

        public static Roman Parse(string str, Dictionary<string, RomanPrimitive> map)
        {
            string[] left = str.Split(' ');
            var number = new StringBuilder();
            left.ToList().ForEach(l => number.Append(map[l].Symbol));
            Roman roman = Parse(number.ToString());
            return roman;
        }

        public static Roman Parse(string str)
        {
            var roman = new Roman();
            char[] chars = str.ToCharArray();
            chars.ToList().ForEach(c => roman._primitives.Add(RomanPrimitive.Parse(c)));
            return roman;

        }
    }
}
