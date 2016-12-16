using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using StampCollectorManager.DAL.Repositories;
using StampCollectorManager.INF.EntityFramework;

namespace StampCollectorManager.Desktop
{
    /// <summary>
    /// Interaction logic for AddStampCollectorWindow.xaml
    /// </summary>
    public partial class AddStampCollectorWindow : Window
    {
        private StampCollectorRepository _stampCollectorRepository = null;
        private StampRepository _stampRepository = null;
        public AddStampCollectorWindow()
        {
            ApplicationContext database = new ApplicationContext();
            this._stampCollectorRepository = new StampCollectorRepository(database);
            this._stampRepository = new StampRepository(database);
            InitializeComponent();

            dataGrid.ItemsSource = this._stampRepository.GetAll().ToList();
            //foreach(Stamp item in this._stampRepository.GetAll())
            //{
            //    d.Items.Add(item.Id);
            //}
        }

        private void stampComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cancleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            bool fail = false;
            if (String.IsNullOrEmpty(firstNameTextBox.Text))
            {
                firstNameValidationMessage.Visibility = Visibility.Visible;
                fail = true;
            }
            else
            {
                firstNameValidationMessage.Visibility = Visibility.Hidden;
            }
            if (String.IsNullOrEmpty(lastNameTextBox.Text))
            {
                lastNameValidationMessage.Visibility = Visibility.Visible;
                fail = true;
            }
            else
            {
                lastNameValidationMessage.Visibility = Visibility.Hidden;
            }
            if (String.IsNullOrEmpty(addressTextBox.Text))
            {
                addressValidationMessage.Visibility = Visibility.Visible;
                fail = true;
            }
            else
            {
                addressValidationMessage.Visibility = Visibility.Hidden;
            }
            if (String.IsNullOrEmpty(countryTextBox.Text))
            {
                countryValidationMessage.Visibility = Visibility.Visible;
                fail = true;
            }
            else
            {
                countryValidationMessage.Visibility = Visibility.Hidden;
            }
            if (!fail)
            {
                StampCollector stampCollector = new StampCollector()
                {
                    FirstName = firstNameTextBox.Text,
                    LastName = lastNameTextBox.Text,
                    Address = addressTextBox.Text,
                    Country = countryTextBox.Text,
                    PhoneNumber = phoneNumberTextBox.Text,
                    Stamps = new List<Stamp>()
                    // new List<Stamp> { _stampRepository.Get(stampComboBox.SelectedItem) }
                };
                foreach (Stamp item in dataGrid.SelectedItems)
                {
                    stampCollector.Stamps.Add(item);
                }

                this._stampCollectorRepository.Create(stampCollector);
                this.Close();
            }

        }
    }
}
