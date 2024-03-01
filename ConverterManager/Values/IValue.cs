using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLib
{
    public interface IValue
    {
        /// <summary>
        /// Метод получения названия физ. величины
        /// </summary>
        /// <returns></returns>
        string GetName();

        /// <summary>
        /// Метод получения списка единиц измерения
        /// </summary>
        /// <returns></returns>
        Dictionary<string, double> GetCoefDict();
    }
}
