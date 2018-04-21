using System;

namespace Übung_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = 432;
            Console.WriteLine(toHexal(value));
        }

        static int toHexal(int value)
        {
            int result = 0;
            int u = value.ToString().Length;
            for (int i = 0; i < u; i++)
            {
                double potency = Math.Pow(6, Convert.ToDouble(i));
                int rest = (value % 10) * Convert.ToInst32(potency);
                result = rest + result;
                value = value / 10;
            }
            return result;
        }

    }
}

