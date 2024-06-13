using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public interface ISaveAddress  //this is part of the library because any UI should be able to save an address by using this interface type.
                                   //not the UI object type. So, forexample, ifwe kept those methods i ncertain ui types.
                                   //Then, we would have to change the UI type to save the address. with each ui, which can make things complicated.
                                   //So, the cleaner way is to make an interface in the library
    {
        void SaveAddress(AddressModel address);
    }
}
