using System;

namespace Übung_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Für Hexalzahl in Dezimalzahl umwandeln:  HtoD     Dezimal in Hexalzahl umwandeln:  DtoH   personalisierte Berechnung:  XtoY");
            string klasse = Console.ReadLine();

            Console.WriteLine("Wie lautet deine Zahl?");
            double input = double.Parse(Console.ReadLine());

            int output = Convert.ToInt32(input);

            int value = Convert.ToInt32(args[0]);
            int toBase = Convert.ToInt32(args[1]);
            int fromBase = Convert.ToInt32(args[2]);                     

            int hex = output;
            int dec = output;

            if (klasse == "HtoD" )
            {
                Console.WriteLine("Die Hexalzahl " + hex + " wird zur Dezimalzahl " + ConvertDecimaltoHexal(hex));
            } 
            
            if (klasse == "DtoH" )
            {
                Console.WriteLine("Die Dezimalzahl " + dec + " wird zur Hexalzahl " + ConvertHexaltoDecimal(dec));
            }

            if (klasse == "XtoY" )
            {
                Console.WriteLine("Die Zahl " + value + " im " + toBase + "er System wird zur Zahl " + ConvertNumberToBaseFromBase(number, toBase, fromBase));
            } 

                                  
        }

        static int ConvertDecimaltoHexal(int hex)
        {
            int result = 0;
            int u = hex.ToString().Length;
            for (int i = 0; i < u; i++)
            {
                double potency = Math.Pow(6, Convert.ToDouble(i));
                int rest = (hex % 10) * Convert.ToInt32(potency);
                result = rest + result;
                hex = hex / 10;
            }
            return result;
        }

        static int ConvertHexaltoDecimal(int dec)
        {
            int result = 0;
            int u = dec.ToString().Length;
            for (int i = 0; i < u; i++)
            {
                double potency = Math.Pow(10, Convert.ToDouble(i));
                int rest = (dec % 6) * Convert.ToInt32(potency);
                result = rest + result;
                dec = dec / 6;
            }
            return result;

        }

        public static int ConvertToBaseFromDecimal(int toBase, int dec)
        {
            int value;
            int modulo;
            int[] arr = new int[4];
            if (0 <= dec && dec <= 1023)
            {
                for (int i = 0; i <= dec.ToString().Length + 2; i++)
                {
                    value = dec / toBase;
                    modulo = dec % toBase;
                    arr[i] = modulo;
                    dec = value;
                }
            }
            Array.Reverse(arr);
            int sum = Convert.ToInt32((string.Join("", arr)));
            return sum;
        }
        public static int ConvertToDecimalFromBase(int fromBase, int number)
        {
            int length = number.ToString().Length;
            int[] array = new int[length];
            int[] arr = new int[length];
            int sum = 0;

            for (int i = 0; i < length; i++)
            {
                array[i] = number % 10;
                number /= 10;
                arr[i] += array[i] * Convert.ToInt32(Math.Pow(fromBase, i));
            }
            for (int j = 0; j < arr.Length; j++)
            {
                sum += arr[j];
            }
            return sum;
        }
        public static int ConvertNumberToBaseFromBase(int number, int toBase, int fromBase)
        {

            if (2 <= fromBase && fromBase <= 10 && 2 <= toBase && toBase <= 10)
            {
                int dec = ConvertToDecimalFromBase(fromBase, number);
                int value = ConvertToBaseFromDecimal(toBase, dec);
                return value;
            }
            return -1;
        }
    }
}

