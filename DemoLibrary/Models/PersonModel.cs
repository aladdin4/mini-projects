using System;
using System.Collections.Generic;
using System.Text;

namespace DemoLibrary.Models {
    public class PersonModel {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime BirthDay { get; set; }
        public bool IsActive { get; set; }
        public List<AddressModel> Addresses { get; set; }
    }
}
