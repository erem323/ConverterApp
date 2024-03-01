using ConverterLib;

class Program
{
    private static List<IValue> _physicValuesList = new List<IValue>();
    private static IValue _value;

    public static List<string> GetMeasureList(string valueName)
    {
        SetIValue(valueName);
        List<string> measureList = new List<string>();
        foreach (var i in _value.GetCoefDict())
        {
            measureList.Add(i.Key);
        }
        return measureList;
    }


    private static void SetIValue(string valueName)
    {
        foreach (var value in _physicValuesList)
        {
            if (value.GetName() == valueName)
            {
                _value = value;
            }
        }
    }
    public static double GetConvertedValue(double num, string from, string to, string physicValue)
    {
        SetIValue(physicValue);

        num *= _value.GetCoefDict()[from];  // в СИ
        num /= _value.GetCoefDict()[to];    // в требуемую единицу изм.

        return num;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Введите значение:");
        double num = Convert.ToDouble(Console.ReadLine());

        Console.Clear();

        Console.WriteLine("Выберите величину:");
        string phValue = Console.ReadLine();

        Console.WriteLine("Перевод из:");
        string from = Console.ReadLine();

        Console.WriteLine("Перевод в:");
        string to = Console.ReadLine();

        if (phValue == "Сила")
        {
            if (from == "Ньютоны" && to == "КилоНьютоны")
            {
                Console.WriteLine(GetConvertedValue(num, from, to, phValue));
            }
            else if (from == "Ньютоны" && to == "МегаНьютоны")
            {
                double result = GetConvertedValue(num, from, to, phValue);
                Console.WriteLine(result);
            }
            else if (from == "КилоНьютоны" && to == "Ньютоны")
            {
                double result = GetConvertedValue(num, from, to, phValue);
                Console.WriteLine(result);
            }
            else if (from == "КилоНьютоны" && to == "МегаНьютоны")
            {
              
                double result = GetConvertedValue(num, from, to, phValue);
                Console.WriteLine(result);
            }
        }

        //["Сила", "Длина", "Мощность", "Давление", "Скорость", "Время"];

        /*Console.WriteLine("Введите значение: ");
        double valueToConvert = double.Parse(Console.ReadLine()); Console.Clear();
        Console.WriteLine("Введите перевод из: "); string fromUnit = Console.ReadLine();
        Console.WriteLine("Введите перевод в: "); string toUnit = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Результат:"); double result = Converter.ConvertLength(valueToConvert, fromUnit, toUnit);
        Console.WriteLine($"{valueToConvert} {fromUnit} = {result} {toUnit}"); */
    }
}