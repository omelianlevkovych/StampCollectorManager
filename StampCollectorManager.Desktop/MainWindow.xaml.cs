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
using System.Windows.Navigation;
using System.Windows.Shapes;
using StampCollectorManager.BLL.Services;
using StampCollectorManager.BLL.Database;
using StampCollectorManager.DAL.Repositories;
using StampCollectorManager.INF.EntityFramework;
using StampCollectorManager.Desktop.Models;
using StampCollectorManager.Desktop.InfoWindows;
namespace StampCollectorManager.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// STYLES, ira, modify
    public partial class MainWindow : Window
    {
        private string getTable = String.Empty;
        private StampRepository _stampRepository = null;
        private StampCollectorRepository _stampCollectorRepository = null;
        private UnitOfWork _unitOfWork = null;
        public MainWindow()
        {
            ApplicationContext database = new ApplicationContext();
            this._stampCollectorRepository = new StampCollectorRepository(database);
            this._stampRepository = new StampRepository(database);
            DatabaseManager databaseManager = new DatabaseManager(_stampRepository, _stampCollectorRepository);
            AdminBL adminBL = new AdminBL(databaseManager);
            this._unitOfWork = new UnitOfWork(adminBL);
            InitializeComponent();
        }

        private void MenuItemViewStamps_Click(object sender, RoutedEventArgs e)
        {
            List<StampModel> stampModels = new List<StampModel>();
            //dataGrid.ItemsSource = this._stampRepository.GetAll().ToList();
            foreach (Stamp item in this._stampRepository.GetAll())
            {
                stampModels.Add(new StampModel()
                {
                    Id = item.Id,
                    CreationYear = item.CreationYear,
                    Features = item.Features,
                    Circulation = item.Circulation,
                    Country = item.Country,
                    OwnerId = (item.StampCollector == null) ? String.Empty : item.StampCollector.Id.ToString(),
                    Price = item.Price
                });
            }
            getTable = "Stamps";
            dataGrid.ItemsSource = stampModels;
            //dataGrid.ItemsSource = this._stampRepository.GetAll().ToList();
        }

        private void MenuItemAddStamp_Click(object sender, RoutedEventArgs e)
        {
            AddStampWindow addWindow = new AddStampWindow();
            addWindow.ShowDialog();
            MenuItemViewStamps_Click(sender, e);
        }

        private void MenuItemViewStampCollectors_Click(object sender, RoutedEventArgs e)
        {
            //string tempIdString = "";
            //List<StampCollectorModel> stampCollectorModels = new List<StampCollectorModel>();
            //foreach (StampCollector item in this._stampCollectorRepository.GetAll().ToList())
            //{
            //    if (item.Stamps != null)
            //    {
            //        List<int> ids = item.Stamps.Select(p => p.Id).ToList();

            //        foreach (int id in ids)
            //        {
            //            tempIdString = tempIdString + " " + id.ToString();
            //        }
            //        stampCollectorModels.Add(new StampCollectorModel()
            //        {
            //            Id = item.Id,
            //            Address = item.Address,
            //            FirstName = item.FirstName,
            //            LastName = item.LastName,
            //            Country = item.Country,
            //            PhoneNumber = item.PhoneNumber,
            //            StampsId = tempIdString
            //        });
            //    }
            //}
            //dataGrid.ItemsSource = stampCollectorModels;


            List<StampCollectorModel> stampCollectors = new List<StampCollectorModel>();
            foreach (StampCollector item in this._stampCollectorRepository.GetAll().ToList())
            {
                if (item.Stamps != null)
                {
                    string collectors = "";
                    List<int> ids = item.Stamps.Select(p => p.Id).ToList();
                    foreach (var id in ids)
                    {
                        collectors += id;
                        collectors += "";
                    }
                    stampCollectors.Add(new StampCollectorModel()
                    {
                        Id = item.Id,
                        Address = item.Address,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Country = item.Country,
                        PhoneNumber = item.PhoneNumber,
                        StampsId = collectors
                    });
                }
                else
                {
                    stampCollectors.Add(new StampCollectorModel()
                    {
                        Id = item.Id,
                        Address = item.Address,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Country = item.Country,
                        PhoneNumber = item.PhoneNumber,
                        StampsId = String.Empty
                    });
                }


            }
            getTable = "StampCollectors";
            dataGrid.ItemsSource = stampCollectors;
            //dataGrid.ItemsSource = this._stampCollectorRepository.GetAll().ToList() ;
        }

        private void MenuItemAddStampCollector_Click(object sender, RoutedEventArgs e)
        {
            AddStampCollectorWindow addWindow = new AddStampCollectorWindow();
            addWindow.ShowDialog();
            MenuItemViewStampCollectors_Click(sender, e);
        }

        //delete
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (getTable)
                {
                    case "Stamps":
                        {
                            foreach (StampModel item in dataGrid.SelectedItems)
                            {
                                this._stampRepository.Delete(item.Id);
                            }
                            MenuItemViewStamps_Click(sender, e);
                            break;
                        }
                    case "StampCollectors":
                        {
                            foreach (StampCollectorModel item in dataGrid.SelectedItems)
                            {
                                this._stampCollectorRepository.Delete(item.Id);
                            }
                            MenuItemViewStampCollectors_Click(sender, e);
                            break;
                        }
                    default: break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Sorry but you can not delete this item");
            }
        }

        private void showInfobutton_Click(object sender, RoutedEventArgs e)
        {
            if (getTable == "Stamps")
            {
                StampInfoWindow stampInfoWindow = new StampInfoWindow(dataGrid.SelectedItem);
                stampInfoWindow.ShowDialog();
            }
            if (getTable == "StampCollectors")
            {
                StampCollectorInfoWindow stampCollectorInfoWindow = new StampCollectorInfoWindow(dataGrid.SelectedItem);
                stampCollectorInfoWindow.ShowDialog();
            }
        }
    }
}
