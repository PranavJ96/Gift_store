using ComboBoxWPF;
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

namespace HorizontalList

{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); 
            DataContext = new ComboBoxViewModel();
            var products = GetProducts();
            if (products.Count > 0)
                ListViewProducts.ItemsSource = products;
        }
        public void giftForSelected(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Contains("Him"))
            {
                DataContext = new ComboBoxViewModel("Him");
            }
            else if(e.AddedItems.Contains("Her"))
            {
                DataContext = new ComboBoxViewModel("Her");
            }
            else if (e.AddedItems.Contains("Teen -> boy"))
            {
                DataContext = new ComboBoxViewModel("Teen -> boy");
            }
            else if (e.AddedItems.Contains("Teen -> girl"))
            {
                DataContext = new ComboBoxViewModel("Teen -> girl");
            }
            else if (e.AddedItems.Contains("Kids -> boy"))
            {
                DataContext = new ComboBoxViewModel("Kids -> boy");
            }
            else if (e.AddedItems.Contains("Kids -> girl"))
            {
                DataContext = new ComboBoxViewModel("Kids -> girl");
            }
            else if (e.AddedItems.Contains("Baby -> boy"))
            {
                DataContext = new ComboBoxViewModel("Baby -> boy");
            }
            else
            {
                DataContext = new ComboBoxViewModel("Baby -> girl");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private List<Product> GetProducts()
        {
            return new List<Product>()
            {
            new Product("Product 1", 205.46, "/Assets/1.jpg"),
            new Product("Product 2", 102.50, "/Assets/2.jpg"),
            new Product("Product 3", 400.99, "/Assets/3.jpg"),
            new Product("Product 4", 350.26, "/Assets/4.jpg"),
            new Product("Product 5", 150.10, "/Assets/5.jpg"),
            new Product("Product 6", 100.02, "/Assets/6.jpg"),
            new Product("Product 7", 295.25, "/Assets/7.jpg"),
            new Product("Product 1", 205.46, "/Assets/1.jpg"),
            new Product("Product 2", 102.50, "/Assets/2.jpg"),
            new Product("Product 3", 400.99, "/Assets/3.jpg"),
            new Product("Product 4", 350.26, "/Assets/4.jpg"),
            new Product("Product 5", 150.10, "/Assets/5.jpg"),
            new Product("Product 6", 100.02, "/Assets/6.jpg"),
            new Product("Product 1", 205.46, "/Assets/1.jpg"),
            new Product("Product 2", 102.50, "/Assets/2.jpg"),
            new Product("Product 3", 400.99, "/Assets/3.jpg"),
            new Product("Product 4", 350.26, "/Assets/4.jpg"),
            new Product("Product 5", 150.10, "/Assets/5.jpg"),
            new Product("Product 6", 100.02, "/Assets/6.jpg"),
            new Product("Product 7", 295.25, "/Assets/7.jpg"),
            new Product("Product 1", 205.46, "/Assets/1.jpg"),
            new Product("Product 2", 102.50, "/Assets/2.jpg"),
            new Product("Product 3", 400.99, "/Assets/3.jpg"),
            new Product("Product 4", 350.26, "/Assets/4.jpg"),
            new Product("Product 5", 150.10, "/Assets/5.jpg"),
            new Product("Product 6", 100.02, "/Assets/6.jpg"),
            new Product("Product 7", 295.25, "/Assets/7.jpg"),
            new Product("Product 1", 205.46, "/Assets/1.jpg"),
            new Product("Product 2", 102.50, "/Assets/2.jpg"),
            new Product("Product 3", 400.99, "/Assets/3.jpg"),
            new Product("Product 4", 350.26, "/Assets/4.jpg"),
            new Product("Product 5", 150.10, "/Assets/5.jpg"),
            new Product("Product 6", 100.02, "/Assets/6.jpg"),
            new Product("Product 7", 295.25, "/Assets/7.jpg"),
            new Product("Product 8", 700.00, "/Assets/8.jpg")
            };
        }
    }
}
