using System;

namespace Übung_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Für Hexalzahl in Dezimalzahl umwandeln:  HtoD     Dezimal in Hexalzahl umwandeln:  DtoH   ");
            string klasse = Console.ReadLine();

            Console.WriteLine("Wie lautet deine Zahl?");
            double input = double.Parse(Console.ReadLine());

            int output = Convert.ToInt32(input);
                     

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

        //static int ConvertToBaseFromDecimal(int toBase, int dec)
        
    }
}

