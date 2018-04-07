using System;

namespace Übung_1b
{
    class Program
    {
        static void Main(string[] args) {

        
            string[] subjects = { "Gandalf", "Frodo", "Boromir", "Sauron", "Galadriel", "Aragorn" };
            string[] verbs = { "trinkt", "braut", "hasst", "zaubert", "schneidet", "beschwört" };
            string[] objects = { "Tüften", "Kraut", "Bier", "Osgiliath", "roter Tobi", "Bree" };
        
            getVerse(subjects, verbs, objects);
        }
    }

    public static void getVerse(string[] subjects, string[] verbs, string[] objects) {
        string verb;
        string subject;
        string objectab;

        for (int i=4; i > -1; i-- ) {
            Random rnd = new Random();
            int rsub = rnd.Next(0, i+1);
            int rver = rnd.Next(0, i+1);
            int robj = rnd.Next(0, i+1);

            subject = subjects[rsub];
            verb = verbs[rver];
            objectab = objects[robj];

            int hsub = i - rsub;
            int hver = i - rver;
            int hobj = i - robj;

            for (int z = hsub; z > 0; z=z - 1 ) {
                subjects [rsub] = subjects [rsub + 1];
                rsub = rsub + 1;
            }

            for (int z = hver; z > 0; z=z - 1) {
                verbs [rver] = verbs [rver + 1];
                rver++;
            }

            for (int z = hobj; z > 0; z=z - 1) {
                objects[robj] = objects[robj + 1];
                robj++;
            }

            Console.WriteLine(subject + " " + verb + " " + objectab);

        }

    }
}