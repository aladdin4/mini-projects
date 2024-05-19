using System;
using System.Collections.Generic;
using System.Text;

namespace GuestBookLibrary.Models
{
    public class FullContactModel
    {
        public BasicContactModel BasicContact { get; set; }
        public List<PhoneNumberModel> PhoneNumbers { get; set; } = new List<PhoneNumberModel>();
        public List<EmailAddressModel> EmailAddresses { get; set; } = new List<EmailAddressModel>();
    }
}
