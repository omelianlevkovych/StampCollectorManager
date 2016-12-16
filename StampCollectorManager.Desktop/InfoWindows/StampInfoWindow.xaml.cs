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
    /// Interaction logic for StampInfoWindow.xaml
    /// </summary>
    public partial class StampInfoWindow : Window
    {
        private StampRepository _stampRepository = null;
        private StampCollectorRepository _stampCollectorRepository = null;
        private StampModel model = null;
        public StampInfoWindow(object stampModel)
        {
            ApplicationContext database = new ApplicationContext();
            this._stampCollectorRepository = new StampCollectorRepository(database);
            this._stampRepository = new StampRepository(database);
            InitializeComponent();
            model = stampModel as StampModel;

            //var image = new Image();
            //var fullFilePath = String.Format("@" + this._stampRepository.Get(model.Id).PhotoUrl);
            //BitmapImage bitmap = new BitmapImage();
            //bitmap.BeginInit();
            //bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            //bitmap.EndInit();

            //image.Source = bitmap;
            //wrapPicture.Children.Add(image);

            try
            {
                idTextBox.Text = model.Id.ToString();
                countryTextBox.Text = model.Country;
                priceTextBox.Text = model.Price.ToString();
                circulationTextBOx.Text = model.Circulation.ToString();
                creationYearTextBox.Text = model.CreationYear.ToString();
                featuresTextBox.Text = model.Features;
            }
            catch(Exception exception)
            {
                MessageBox.Show("Sorry but " + exception.Message);
            }
        }

        private void modifyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Stamp stamp = this._stampRepository.Get(int.Parse(idTextBox.Text));
                stamp.Circulation = int.Parse(circulationTextBOx.Text);
                stamp.Country = countryTextBox.Text;
                stamp.CreationYear = int.Parse(creationYearTextBox.Text);
                stamp.Features = featuresTextBox.Text;
                stamp.Price = decimal.Parse(priceTextBox.Text);
                this._stampRepository.Update(stamp);
        }
            catch (Exception exception)
            {
                MessageBox.Show("Sorry but " + exception.Message);
            }
            this.Close();
        }

        private void CancleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
