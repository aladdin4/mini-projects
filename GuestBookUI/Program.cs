using GuestBookLibrary.Models;
using System;
using System.Collections.Generic;

namespace GuestBookUI {
    class Program {

        private static List<GuestModel> guests = new List<GuestModel>();

        static void Main(string[] args) {

            Console.WriteLine("Welcome to the Guest Book!");

            CollectGuestInfo();
            PrintGuests();
        }

        static void CollectGuestInfo() {
            string moreGuests = "";
            do
            {
                GuestModel guest = new GuestModel();
                guest.FirstName =  GetInfo("Please enter First Name: ");
                guest.LastName = GetInfo("Please enter Last Name: ");
                guest.MessageToHost = GetInfo("Please enter Message To Host: ");

                guests.Add(guest);

                moreGuests = GetInfo("Do you want to add another guest? (yes/no)");
            } while (moreGuests.ToLower() == "yes");
        }

        static string GetInfo(string message) {
            Console.Write(message);
            return Console.ReadLine();
        }


        static void PrintGuests() {
            foreach (var guest in guests)
            {
                Console.WriteLine(guest.GuestInfo);
            }
        }
    }
}
