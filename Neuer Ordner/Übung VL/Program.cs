﻿using System;

namespace Übung_VL
{
    class Program
    {
        static void Main(string[] args)
        {
            Person einePerson = new Person();
            einePerson.FirstName = "Horst";
            einePerson.Age = 42;

            Console.WriteLine("Name: " + einePerson.FirstName + "   Alter: " + einePerson.Age);
            
        }

        public class Person
        {
            public string FirstName;
            public int Age;
            public override string ToString()
            {
                return FirstName + "  " + Age;
            }
        }
    }
}
