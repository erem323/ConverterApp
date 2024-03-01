using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLib.Values
{
    internal class Force : IValue
    {
        private string _name = "Сила";

        private Dictionary<string, double> _coefDict = new Dictionary<string, double>()
        {
            { "Ньютоны",        1 },
            { "КилоНьютоны",    1000 },
            { "МегаНьютоны",    1000000 }            
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
