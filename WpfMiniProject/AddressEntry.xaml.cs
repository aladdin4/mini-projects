using DemoLibrary;
using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfMiniProject
{
    /// <summary>
    /// Interaction logic for AddressEntry.xaml
    /// </summary>
    public partial class AddressEntry : Window
    {
        ISaveAddress _parent;
        public AddressEntry(ISaveAddress parent)
        {
            InitializeComponent();
            _parent = parent;   // saving the parent object for long term use.
        }

        private void saveAddress_Click(object sender, RoutedEventArgs e)
        {
            AddressModel newAddress = new AddressModel
            {
                City = cityText.Text,
                StreetAddress = streetAddressText.Text,
                State = stateText.Text,
                ZipCode = zipCodeText.Text
            };
            _parent.SaveAddress(newAddress);
            this.Close();
        }
    }
}
