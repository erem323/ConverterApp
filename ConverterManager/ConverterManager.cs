using ConverterManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLib
{
    public class ConverterManager
    {
        private static List<IValue> _physicValuesList = new List<IValue>();

        /// <summary>
        /// Метод погружает список величин из библиотеки классов
        /// </summary>
        private static void SetValuesList()
        {
            Assembly asm = Assembly.LoadFrom("ConverterLib.dll");           // создание сборки из библиотеки классов
            Type[] types = asm.GetTypes();                                  // выгрузка классов в массив
            foreach (Type type in types)                                    // перебираем классы и интерфейсы
            {
                if ((type.IsInterface == false)
                    && (type.IsAbstract == false)
                    && (type.Name != ("AnyValue"))                          // добавил, чтобы исключить базовый класс
                    && (type.GetInterface("IValue") != null))               // не добавляем абстрактные классы и интерфейсы
                {
                    IValue value = (IValue)Activator.CreateInstance(type);
                    _physicValuesList.Add(value);                           // подгружаем этот класс в список уроков                        
                }
            }
        }

        public List<string> GetPhysValuesList()
        {
            SetValuesList();
            List<string> physicValuesList = new List<string>();
            foreach (var i in _physicValuesList)
            {
                physicValuesList.Add(i.GetName());
            }
            return physicValuesList;
        }

        // переменная для получения конкретной физ. величины
        private IValue _value;

        /// <summary>
        /// Метод формирует и возвращает список единиц измерения физ. величины
        /// </summary>
        /// <returns></returns>
        public List<string> GetMeasureList(string valueName)
        {
            SetIValue(valueName);
            List<string> measureList = new List<string>();
            foreach (var i in _value.GetCoefDict())
            {
                measureList.Add(i.Key);
            }
            return measureList;
        }


        private void SetIValue(string valueName)
        {
            foreach (var value in _physicValuesList)
            {
                if (value.GetName() == valueName)
                {
                    _value = value;
                }
            }
        }

        /// <summary>
        /// Метод возвращает конвертированное значение
        /// </summary>
        /// <param name="num">Конвертируемое значение</param>
        /// <param name="from">Исходные единицы измерения</param>
        /// <param name="to">Единицы измерения, в которые нужно перевести</param>
        /// <returns></returns>
        public double GetConvertedValue(double num, string from, string to, string physicValue)
        {
            SetIValue(physicValue);

            num *= _value.GetCoefDict()[from];  // в СИ
            num /= _value.GetCoefDict()[to];    // в требуемую единицу изм.

            return num;
        }

    }
}
