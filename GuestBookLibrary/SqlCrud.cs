using GuestBookLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GuestBookLibrary
{
    public class SqlCrud
    {
        private readonly string _connectionString;
        private SqlDataAccess db = new SqlDataAccess();
        public SqlCrud(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<BasicContactModel> GetAllContacts()
        {
            string sql = "select Id, FirstName, LastName from dbo.Contacts";

            //we use dynamic here because we are not passing any parameters to the query, == anon {}
            return db.LoadData<BasicContactModel, dynamic>(sql, new { }, _connectionString);
        }

        public FullContactModel GetFullContactById(int id3)
        {
            string sql = "select Id, FirstName, LastName from dbo.Contacts where Id = @Id2";
            FullContactModel output = new FullContactModel();
            output.BasicContact = db.LoadData<BasicContactModel, dynamic>(sql, new { Id2 = id3 }, _connectionString).FirstOrDefault();

            if (output.BasicContact == null)
            {
                return null;
            }
            sql = @"select e.*
                    from EmailAddresses e
                    inner join ContactEmail ce
                    on ce.EmailAddressId = e.Id
                    where ce.ContactId = @Id4";

            output.EmailAddresses = db.LoadData<EmailAddressModel, dynamic>(sql, new { Id4 = id3 }, _connectionString);

            sql = @"select p.*
                    from PhoneNumbers p
                    inner
                    join ContactPhoneNumbers cp
                    on cp.PhoneNumberId = p.Id
                    where cp.ContactId = @Id5";
            output.PhoneNumbers = db.LoadData<PhoneNumberModel, dynamic>(sql, new { Id5 = id3 }, _connectionString);


            return output;
        }

        public void CreateContact(FullContactModel contact)
        {
            //1. Insert the basic contact
            string sql = "insert into dbo.Contacts (FirstName, LastName) values (@FirstName, @LastName);";
            db.SaveData(sql,
                new { contact.BasicContact.FirstName, contact.BasicContact.LastName, }
                , _connectionString);
            //2. Get the id of the newly created contact
            sql = "select Id from dbo.contacts where FirstName = @FirstName and LastName = @lastName";
            int contactId = db.LoadData<IdLookupModel, dynamic>(sql,
                               new { contact.BasicContact.FirstName, contact.BasicContact.LastName }
                                              , _connectionString).First().Id;

            foreach (var phoneNumber in contact.PhoneNumbers)
            {   //3. Identify if phone number exist
                if (phoneNumber.id == 0)
                {

                    sql = "insert into dbo.phoneNumbers (phoneNumber) values(@phoneNumber);";
                    db.SaveData(sql, new { phoneNumber.PhoneNumber }, _connectionString);

                    sql = "select Id from dbo.phoneNumbers where PhoneNumber = @PhoneNumber";
                    phoneNumber.id = db.LoadData<IdLookupModel, dynamic>(sql, new { phoneNumber.PhoneNumber }, _connectionString).First().Id;
                }
                //4. insert into the contactPhoneNumber table
                sql = "insert into dbo.contactPhoneNumbers (ContactId, PhoneNumberId) values (@ContactId, @PhoneNumberId);";

                db.SaveData(sql, new { ContactId = contactId, PhoneNumberId = phoneNumber.id }, _connectionString);
            }

            foreach (var email in contact.EmailAddresses)
            {
                if (email.Id == 0)
                {
                    sql = "insert into dbo.EmailAddresses (EmailAddress) values(@EmailAddress);";
                    db.SaveData(sql, new { email.EmailAddress }, _connectionString);

                    sql = "select Id from dbo.EmailAddresses where EmailAddress =  @EmailAddress;";
                    email.Id = db.LoadData<IdLookupModel, dynamic>(sql, new { email.EmailAddress }, _connectionString).First().Id;
                }

                sql = "insert into dbo.contactEmail (contactId, EmailAddressId) values (@contactId, @EmailAddressId);";
                db.SaveData(sql, new { contactId, EmailAddressId = email.Id }, _connectionString);
            }

        }

        public void UpdateContact(BasicContactModel contact)
        {
            string sql = "update dbo.contacts set FirstName = @FirstName, LastName = @LastName Where Id = @Id;";
            db.SaveData(sql, contact, _connectionString);
        }

        public void RemoveContactPhoneNumber(int contactId, int phoneNumberId)
        {
            string sql = "select Id, ContactId, PhoneNumberId from dbo.ContactPhoneNumbers where PhoneNumberId = @phoneNumberId;";
            List<ContactPhoneNumberModel> links = new List<ContactPhoneNumberModel>();
            links = db.LoadData<ContactPhoneNumberModel, dynamic>(sql, new { phoneNumberId }, _connectionString).ToList();

            //deleting the link
            sql = "delete from dbo.ContactPhoneNumbers where ContactId = @contactId and PhoneNumberId = @phoneNumberId;";
            db.SaveData(sql, new { contactId, phoneNumberId }, _connectionString);

            //remove the phone number if has no links
            if (links.Count == 1)
            {
                sql = "delete from dbo.PhoneNumbers where Id = @phoneNumberId;";
                db.SaveData(sql, new { phoneNumberId }, _connectionString);
            }
        }
    }
}
