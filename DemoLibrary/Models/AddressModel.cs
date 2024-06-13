using System;
using System.Collections.Generic;
using System.Text;

namespace DemoLibrary.Models
{
    public class AddressModel
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }  // 00852-2541 (that's why it's a string) (it may be a digits, but not a number, i.e. not treated as a number)
    
        public string FullAddress => $"{StreetAddress}, {City}, {State}  {ZipCode}";
    }
}
