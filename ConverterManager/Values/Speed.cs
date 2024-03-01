using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLib.Values
{
    internal class Speed : IValue
    {
        private string _name = "Скорость";

        private Dictionary<string, double> _coefDict = new Dictionary<string, double>()
        {
            { "м/с",        1 },
            { "км/мин",    16.667 },
            { "км/ч",    0.278 },
            { "м/ч",    0.0003 },
            { "миля/ч",    0.447 }
        };

        public Dictionary<string, double> GetCoefDict()
        {
            return _coefDict;
        }

        public string GetName()
        {
            return _name;
        }
    }
}
