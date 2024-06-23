using DemoLibrary;
using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfMiniProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ISaveAddress
    {
        BindingList<AddressModel> addresses = new BindingList<AddressModel>();

        public MainWindow()
        {
            InitializeComponent();
            adressesList.ItemsSource = addresses;
            addresses.Add(new AddressModel { StreetAddress = "123 Main St", City = "Columbus", State = "Ohio", ZipCode = "43215" });
            addresses.Add(new AddressModel {  StreetAddress = "456 Elm St", City = "Columbus2", State = "Ohio2", ZipCode = "8910" });
        }

        public void SaveAddress(AddressModel address)
        {
            addresses.Add(address);
        }
        private void addAddress_Click(object sender, RoutedEventArgs e)
        {
            AddressEntry adress = new AddressEntry(this);
            adress.Show();
        }
        private void savePerson_Click(object sender, RoutedEventArgs e)
        {
            PersonModel personModel = new PersonModel
            {
                FirstName = firstNameText.Text,
                LastName = lastNameText.Text,
                IsActive = activeCheckBox.IsChecked ?? false,
                Addresses = addresses.ToList()
            };
        }
    }
}
