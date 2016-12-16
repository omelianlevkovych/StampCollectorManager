using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using StampCollectorManager.BLL.Services;
using StampCollectorManager.BLL.Database;
using StampCollectorManager.DAL.Repositories;
using StampCollectorManager.INF.EntityFramework;
using StampCollectorManager.Desktop.Models;
namespace StampCollectorManager.Desktop.InfoWindows
{
    /// <summary>
    /// Interaction logic for StampCollectorInfoWindow.xaml
    /// </summary>
    public partial class StampCollectorInfoWindow : Window
    {
        private StampRepository _stampRepository = null;
        private StampCollectorRepository _stampCollectorRepository = null;
        private StampCollectorModel model = null;
        public StampCollectorInfoWindow(object stampCollectorModel)
        {
            ApplicationContext database = new ApplicationContext();
            this._stampCollectorRepository = new StampCollectorRepository(database);
            this._stampRepository = new StampRepository(database);
            InitializeComponent();
            model = stampCollectorModel as StampCollectorModel;

            try
            {
                idtextBox.Text = model.Id.ToString();
                countrytextBox.Text = model.Country;
                firstNametextBox.Text = model.FirstName;
                lastNametextBox.Text = model.LastName;
                addresstextBox.Text = model.Address;
                phonetextBox.Text = model.PhoneNumber;
            }
            catch(Exception exception)
            {
                MessageBox.Show("Sorry but " + exception.Message);
            }
        }

        private void cancleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void modifyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StampCollector stampCollector = this._stampCollectorRepository.Get(int.Parse(idtextBox.Text));

                stampCollector.Address = addresstextBox.Text;
                stampCollector.Country = countrytextBox.Text;
                stampCollector.FirstName = firstNametextBox.Text;
                stampCollector.LastName = lastNametextBox.Text;
                stampCollector.PhoneNumber = phonetextBox.Text;
                this._stampCollectorRepository.Update(stampCollector);
            }
            catch(Exception exception)
            {
                MessageBox.Show("Sorry but " + exception.Message);
            }
            this.Close();
        }
    }
}
