using System;

namespace Aufgabe1._2
{
    class Program
    {
        static string[] subjects = { "Gandalf", "Frodo", "Boromir", "Sauron", "Galadriel", "Aragorn" };
        static string[] verbs = { "trinkt", "braut", "hasst", "zaubert", "schneidet", "beschwört" };
        static string[] objects = { "Tüften", "Kraut", "Bier", "Osgiliath", "roter Tobi", "Bree" };
        
        getVerse(subjects, verbs, objects);
    }

    public static void getVerse(string[] subjects, string[] verbs, string[] objects) {
        string verb;
        string subject;
        string objectab;

        for (int i=4; i > -1; i-- ) {
            Random rnd = new Random();
            int rsub = rnd.Next(0, i+1)
            int rver =
            int robj =

        }

    }
