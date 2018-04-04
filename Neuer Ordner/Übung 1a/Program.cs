using System;

namespace Übung_1a
{
    class Program
    {
      
        static void Main(string[] args)
        {
            
           Console.WriteLine("Für Würfel -> w , Für Kugel -> k , Für Oktaeder -> o");
           string klasse = Console.ReadLine();

           Console.WriteLine("Der Durchmesser d beträgt?");
           double d = Console.Read();

           if (klasse == "w" ) 
            {
                Console.WriteLine("Die Oberfläche beträgt: " + getCubeOberflaeche(d));
                Console.WriteLine("Das Volumen beträgt: " + getCubeVolumen(d));
            }

            if (klasse == "k")
            {
                Console.WriteLine("Die Oberfläche beträgt: " + getSphereOberflaeche(d));
                Console.WriteLine("Das Volumen beträgt: " + getSphereVolumen(d));
            }
            
            if (klasse == "o"){
                Console.WriteLine("Die Oberfläche beträgt: " + getOktaOberflaeche(d));
                Console.WriteLine("Das Volumen beträgt: " + getOktaVolumen(d));
            }
                  
                               
        }

        public static double getCubeOberflaeche(double d) {
            double oberflaeche = (d*d)*6;
            return oberflaeche;
        }

        public static double getCubeVolumen(double d) {
            double volumen = d*d*d;
            return volumen;
        }

         public static double getSphereOberflaeche(double d) {
            double oberflaeche = d*d*3.14;
            return oberflaeche;
        }

        public static double getSphereVolumen(double d) {
            double volumen = ((d*d*d)*3.14)/6;
            return volumen;
        }

        public static double getOktaOberflaeche(double d) {
            double oberfläche = 2 * Math.Sqrt(3) * (d * d);
            return oberfläche;
        }

        public static double getOktaVolumen(double d) {
            double volumen = (Math.Sqrt(2) * (d * d * d)) / 3;
            return volumen;
        }


    }
}
