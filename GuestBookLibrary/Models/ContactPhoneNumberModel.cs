using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Security.Principal;
using System.Text;

namespace GuestBookLibrary.Models
{
    public class ContactPhoneNumberModel
    {
        public int Id{ get; set; }
        public int ContactId { get; set; }
        public int PhoneNumberId { get; set; }
    }
}
