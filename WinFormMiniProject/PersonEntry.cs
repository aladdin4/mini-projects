using System;
using DemoLibrary.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoLibrary;

namespace WinFormMiniProject
{
    public partial class PersonEntry : Form, ISaveAddress
    {                                                
        BindingList<AddressModel> addresses = new BindingList<AddressModel>();
        public PersonEntry()
        {
            InitializeComponent();
            addressesList.DataSource = addresses;
            addressesList.DisplayMember = nameof(AddressModel.FullAddress);
        }

        private void addNewAddressBtn_Click(object sender, EventArgs e)
        {
            AddressEntry entry = new AddressEntry(this);
            entry.Show();
        }

        public void SaveAddress(AddressModel address) //how the child could call this?
        {
            addresses.Add(address);
        }

        private void saveRecord_Click(object sender, EventArgs e)
        {
            PersonModel person = new PersonModel
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                Addresses = addresses.ToList(),
                IsActive = isActiveCheckBox.Checked
            };
        }
    }
}
