using System;

namespace Mail_Checker
{
    class Program
    {
        public static bool IsEmailAddress(string emailAdress)
        {
            int iAt = emailAdress.IndexOf('@');
            int iDot = emailAdress.LastIndexOf('.');
            return (iAt > 0 && iDot > iAt);

        }



        static void Main(string[] args)
        {
            Console.WriteLine(IsEmailAddress("irgendwas@yahoo.de"));

            Console.WriteLine(IsEmailAddress("@yahoo.de"));

            Console.WriteLine(IsEmailAddress("hallo.kohler@yahoo.de"));
        }
    }
}
