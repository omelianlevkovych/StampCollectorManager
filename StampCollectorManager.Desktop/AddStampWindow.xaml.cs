using System.Linq;
using System.Windows;
using StampCollectorManager.DAL.Repositories;
using StampCollectorManager.INF.EntityFramework;

namespace StampCollectorManager.Desktop
{
    /// <summary>
    /// Interaction logic for AddStampWindow.xaml
    /// </summary>
    public partial class AddStampWindow : Window
    {
        private StampCollectorRepository _stampCollectorRepository = null;
        private StampRepository _stampRepository = null;
        public AddStampWindow()
        {
            ApplicationContext database = new ApplicationContext();
            this._stampCollectorRepository = new StampCollectorRepository(database);
            this._stampRepository = new StampRepository(database);
            InitializeComponent();

            comboBox.ItemsSource = this._stampCollectorRepository.GetAll().ToList().Select(p => p.LastName);
        }

        private void cancleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            Stamp stamp = new Stamp()
            {
                Country = countryTextBox.Text,
                Features = featureTextBox.Text,
                Circulation = int.Parse(circulationTextBox.Text),
                PhotoUrl = photoUrlTextBox.Text,
                Price = decimal.Parse(priceTextBox.Text),
                CreationYear = int.Parse(priceTextBox.Text),
                StampCollector = this._stampCollectorRepository.GetByLastName(comboBox.SelectedItem.ToString())
            };

            this._stampRepository.Create(stamp);
            this.Close();
        }
    }
}
