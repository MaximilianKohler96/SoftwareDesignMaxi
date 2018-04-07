using System;

namespace Aufgabe1._2
{
    class Program
    {
        static string[] subjects = { "Gandalf", "Frodo", "Boromir", "Sauron", "Galadriel", "Aragorn" };
        static string[] verbs = { "trinkt", "braut", "hasst", "zaubert", "schneidet", "beschwört" };
        static string[] objects = { "Tüften", "Kraut", "Bier", "Osgiliath", "roter Tobi", "Bree" };
        
        static int l = subjects.Length;
        static string w1;
        static string w2;
        static string w3;
        static void Main(string[] args)
        {
            
            string[] verse = new string[l];
            for (int i = 0; i < l; i++)
            {
                GetVerse();
                verse[i] = w1 + " " + w2 + " " + w3;
            }
            for (int v = 0; v < l; v++)
            {
                Console.WriteLine(verse[v]);
            }
        }

        public static void GetVerse()
        {
            Random rnd = new Random();

            int s = rnd.Next(0, l); 
            int v = rnd.Next(0, l); 
            int o = rnd.Next(0, l); 

            while (subjects[s] == "used")
            {
                s = rnd.Next(0, l);
            }
            while (verbs[v] == "used")
            {
                v = rnd.Next(0, l);
            }
            while (objects[o] == "used")
            {
                o = rnd.Next(0, l);
            }
            w1 = subjects[s];
            w2 = verbs[v];
            w3 = objects[o];

            subjects[s] = "used";
            verbs[v] = "used";
            objects[o] = "used";
        }
    }
}
