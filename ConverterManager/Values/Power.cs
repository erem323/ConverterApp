using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLib.Values
{
    internal class Power : IValue
    {
        private string _name = "Мощность";

        private Dictionary<string, double> _coefDict = new Dictionary<string, double>()
        {
            { "Киловатт",        1 },
            { "Мегаватт",    1000 },
            { "Ватт", 0.001}
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
