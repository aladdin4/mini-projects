using GuestBookLibrary;
using GuestBookLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace GuestBookUI {
    class Program {

        private static List<GuestModel> guests = new List<GuestModel>();

        static void Main(string[] args) {

            Console.WriteLine("Welcome to the Guest Book!");
            SqlCrud sql = new SqlCrud(GetConnectionString());

           

            //UpdateContact(sql);

            ReadFullContactById(sql,1);


            // Console.WriteLine("");

            //ReadFullContactById(sql,2);
            //CollectGuestInfo();
            //PrintGuests();
            //RemoveContactPhoneNumber(sql); 
            //CreateNewContact(sql);
            ReadAllContacts(sql);
        }

        static string GetConnectionString(string connectionStringName = "Default")
        {
            string output = "";
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var config = builder.Build();
            output = config.GetConnectionString(connectionStringName);
            return output;
        }

        static void ReadAllContacts(SqlCrud sql) {
            var rows = sql.GetAllContacts();
            foreach (var row in rows)
            {
                Console.WriteLine($"{row.Id}: {row.FirstName} {row.LastName}");
            }
        }

        static void ReadFullContactById(SqlCrud sql, int id)
        {
            var contact = sql.GetFullContactById(id);
            if (contact == null)
            {
                Console.WriteLine("Contact not found");

            }
            else
            {
                Console.Write($"{contact.BasicContact.Id}: {contact.BasicContact.FirstName} {contact.BasicContact.LastName}. ");
                foreach (var email in contact.EmailAddresses)
                {
                    Console.Write($" Email: {email.EmailAddress}.");
                }
                foreach (var phone in contact.PhoneNumbers)
                {
                    Console.Write($" Phone: {phone.PhoneNumber}.");
                }
            }
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

        static void CreateNewContact(SqlCrud sql)
        {
            FullContactModel newUser = new FullContactModel
            {
                BasicContact = new BasicContactModel
                {
                    FirstName = "Tim",
                    LastName = "Corey"
                }
            };

            newUser.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "Tim1@Corey.cc" });
            newUser.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "Tim2@Corey.cc" });

            newUser.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "111-111-111" });
            newUser.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "222-222-222" });

            sql.CreateContact(newUser);
        }

        static void UpdateContact(SqlCrud sql)
        {
            BasicContactModel contact = new BasicContactModel
            {
                Id = 1,
                FirstName = "edited Charity",
                LastName = "edited Corey"
            };
            sql.UpdateContact(contact);
        }

        static void RemoveContactPhoneNumber(SqlCrud sql)
        {
            sql.RemoveContactPhoneNumber(1, 2);
        }
    }
}
