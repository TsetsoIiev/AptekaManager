using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

using Microsoft.Win32;

using AptekaManager.Internal.Dto;
using System.IO;

namespace AptekaManager.Inventory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class DataObject
        {
            public DataObject()
            {
            }

            public DataObject(ProductDto productDto)
            {
                this.Name = productDto.Name;
                this.Price = productDto.Price;
                this.Quantity = productDto.Quantity;
                this.Description = productDto.Description;
                this.MeasurementUnitsPerBox = productDto.MeasurementUnitsPerBox;
                this.IsSeparableSale = productDto.IsSeparableSale;
            }

            public string Name { get; set; }

            public decimal Price { get; set; }

            public decimal Quantity { get; set; }

            public string Description { get; set; }

            public int MeasurementUnitsPerBox { get; set; }

            public bool IsSeparableSale { get; set; }
        }

        private ObservableCollection<DataObject> pharmacyListedProducts = new ObservableCollection<DataObject>();
        private ICollection<DataObject> loadedProducts;

        public MainWindow()
        {
            InitializeComponent();
            this.LoadProducts();
        }

        public void AddElementToGrid(ProductDto productDto)
        {
            var parsedProduct = new DataObject(productDto);
            pharmacyListedProducts.Add(parsedProduct);
        }

        private void SearchBTN_Click(object sender, RoutedEventArgs e)
        {
            var name = this.SearchTB.Text;
            var elements = this.pharmacyListedProducts.Where(x => x.Name.Contains(name)).ToList();
            this.pharmacyListedProducts.Clear();
            foreach (var el in elements)
            {
                this.pharmacyListedProducts.Add(el);
            }
        }

        private void LoadProducts()
        {
            this.dataGrid1.ItemsSource = pharmacyListedProducts;
            this.loadedProducts = new List<DataObject>();

            var el1 = new DataObject() { Name = "Валериан", Price = 1.2m, Quantity = 20, MeasurementUnitsPerBox = 20, IsSeparableSale = false, Description = "Descr" };
            var el2 = new DataObject() { Name = "Аспирин СоФарма", Price = 1.12m, Quantity = 20, MeasurementUnitsPerBox = 20, IsSeparableSale = false, Description = "Descr" };
            var el3 = new DataObject() { Name = "Терафлу СоФарма", Price = 4.80m, Quantity = 20, MeasurementUnitsPerBox = 20, IsSeparableSale = false, Description = "Descr" };
            var el4 = new DataObject() { Name = "Терафлу Байерн", Price = 3.5m, Quantity = 20, MeasurementUnitsPerBox = 20, IsSeparableSale = false, Description = "Descr" };

            pharmacyListedProducts.Add(el1);
            pharmacyListedProducts.Add(el2);
            pharmacyListedProducts.Add(el3);
            pharmacyListedProducts.Add(el4);

            this.loadedProducts.Add(el1);
            this.loadedProducts.Add(el2);
            this.loadedProducts.Add(el3);
            this.loadedProducts.Add(el4);

            ApiConnection apiConnection = new ApiConnection();
            var products = apiConnection.GetProducts();

            products.ToList().ForEach((x) =>
            {
                this.pharmacyListedProducts.Add(new DataObject(x));
                this.loadedProducts.Add(new DataObject(x));
            });
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var name = this.SearchTB.Text.ToLower();
            var elements = this.loadedProducts.Where(x => x.Name.ToLower().Contains(name)).ToList();

            this.pharmacyListedProducts.Clear();
            foreach (var el in elements)
            {
                this.pharmacyListedProducts.Add(el);
            }
        }

        private void AddCSV_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            openFileDialog.ShowDialog();

            var filePath = openFileDialog.FileName;
            var csvParser = new CSVParser(filePath);
            var data = csvParser.ParseCSV();

            this.AddProductsToList(data);
            new ApiConnection().InsertProducts(data);
        }

        private void AddProductsToList(IEnumerable<ProductDto> products)
        {
            products.ToList().ForEach((x) => this.pharmacyListedProducts.Add(new DataObject(x)));
            products.ToList().ForEach((x) => this.loadedProducts.Add(new DataObject(x)));
            
            this.SearchTB.Text = "";
        }
    }
}