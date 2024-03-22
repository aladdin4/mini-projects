using DemoLibrary.Models;
using System;

namespace chapter_04 {
    internal class Program {
        static void Main(string[] args) {
            
            PersonModel person = new PersonModel();
            person.FirstName = "Tim";
            person.LastName = "Corey";
            person.Title = "Mr.";
            person.BirthDay = new DateTime(1980, 1, 1);

            Console.WriteLine("Hello World!");
            Console.WriteLine($"Hello {person.Title} {person.FirstName} {person.LastName} born on {person.BirthDay}");
            Console.ReadLine();
        }
    }
}
