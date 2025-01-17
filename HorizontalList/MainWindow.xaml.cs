﻿using ComboBoxWPF;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
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
        public string newProductFileName;
        public string giftFor = "";
        public string ocassion = "";
        public string sortBy = "Price -> Low";
        public double totalAmount;
        public int lastEditedProductID;
        public ObservableCollection<Product> showingProducts;
        public List<AddedProduct> addedProducts = new List<AddedProduct>();
        public MainWindow()
        {
            InitializeComponent(); 
            DataContext = new ComboBoxViewModel();
            //App._Products.Clear();
            totalAmountText.Text = totalAmount.ToString();
            showingProducts = App._Products;
            //var lang = Settings.Default.language;
            //CultureInfo.CurrentUICulture = new CultureInfo(lang);
            //CultureInfo.CurrentCulture = new CultureInfo(lang);
            //Settings.Default.language = "en-US";
            //Settings.Default.Save();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListViewProducts.ItemsSource = showingProducts;
        }
        public void giftForSelected(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Contains("Him"))
            {
                giftFor = "Him";
                DataContext = new ComboBoxViewModel("Him");
                CBx_OcassionCategory.IsEnabled = true;
            }
            else if(e.AddedItems.Contains("Her"))
            {
                giftFor = "Her";
                DataContext = new ComboBoxViewModel("Her");
                CBx_OcassionCategory.IsEnabled = true;
            }
            else if (e.AddedItems.Contains("Teen -> boy"))
            {
                giftFor = "Teen -> boy";
                DataContext = new ComboBoxViewModel("Teen -> boy");
                CBx_OcassionCategory.IsEnabled = true;
            }
            else if (e.AddedItems.Contains("Teen -> girl"))
            {
                giftFor = "Teen -> girl";
                DataContext = new ComboBoxViewModel("Teen -> girl");
                CBx_OcassionCategory.IsEnabled = true;
            }
            else if (e.AddedItems.Contains("Kids -> boy"))
            {
                giftFor = "Kids -> boy";
                DataContext = new ComboBoxViewModel("Kids -> boy");
                CBx_OcassionCategory.IsEnabled = true;
            }
            else if (e.AddedItems.Contains("Kids -> girl"))
            {
                giftFor = "Kids -> girl";
                DataContext = new ComboBoxViewModel("Kids -> girl");
                CBx_OcassionCategory.IsEnabled = true;
            }
            else if (e.AddedItems.Contains("Baby -> boy"))
            {
                giftFor = "Baby -> boy";
                DataContext = new ComboBoxViewModel("Baby -> boy");
                CBx_OcassionCategory.IsEnabled = true;
            }
            else if (e.AddedItems.Contains("Baby->girl"))
            {
                giftFor = "Baby -> girl";
                DataContext = new ComboBoxViewModel("Baby -> girl");
                CBx_OcassionCategory.IsEnabled = true;
            }
            else
            {
                giftFor = "Show All";
                DataContext = new ComboBoxViewModel("Show All");
                CBx_OcassionCategory.IsEnabled = false;
            }
            ocassion = "";
            sortShowingItems();
        }
        public void sortShowingItems()
        {
            if (giftFor != "" && ocassion != "" && giftFor != "Show All" && ocassion != "Show All")
            {
                showingProducts = new ObservableCollection<Product>(App._Products.Where(x => x.GiftFor == giftFor && x.Ocassion == ocassion));
            }
            else if (ocassion != "" && ocassion != "Show All")
            {
                showingProducts = new ObservableCollection<Product>(App._Products.Where(x => x.Ocassion == ocassion));
            }
            else if (giftFor != "" && giftFor != "Show All" || giftFor != "" && ocassion == "Show All" && giftFor != "Show All")
            {
                showingProducts = new ObservableCollection<Product>(App._Products.Where(x => x.GiftFor == giftFor));
            }
            else
            {
                showingProducts = App._Products;
            }
            if(sortBy.Contains("Price -> Low"))
            {
                showingProducts = new ObservableCollection<Product>(showingProducts.OrderBy(x => x.Value));
            }
            else
            {
                showingProducts = new ObservableCollection<Product>(showingProducts.OrderByDescending(x => x.Value));
            }
            ListViewProducts.ItemsSource = showingProducts;
        }
        public void giftSearch(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                ocassion = e.AddedItems[0].ToString();
                sortShowingItems();
            }
        }
        public void RemoveItemFromCart(object sender, RoutedEventArgs e)
        {
            var itemToRemove = addedProducts.FindIndex(x => x.ID == (int)((System.Windows.FrameworkElement)sender).Tag);
            totalAmount = totalAmount - (addedProducts[itemToRemove].Value * addedProducts[itemToRemove].SelectedItemCount);
            addedProducts.RemoveAt(itemToRemove);
            AddCart(addedProducts);
            totalAmountText.Text = totalAmount.ToString();
        }
        public void AddItemToCart(object sender, RoutedEventArgs e)
         {
            var obj = App._Products.First(x => x.ID == (int)((System.Windows.FrameworkElement)sender).Tag);
            AddedProduct tempobj = new AddedProduct(obj.ID, obj.Name, obj.Value, obj.ImagePath, obj.ItemsLeft);
            
            if (addedProducts!= null && addedProducts.Any(x => x.ID == (int)((System.Windows.FrameworkElement)sender).Tag))
            {
                MessageBox.Show("Item already added");
            }
            else
            {
                totalAmount = totalAmount + tempobj.Value;
                addedProducts.Add(tempobj);
                AddCart(addedProducts);
                totalAmountText.Text = totalAmount.ToString();
                ListViewProducts.ItemsSource = null;
                ListViewProducts.ItemsSource = showingProducts;

            }
            //DataContext = new ComboBoxViewModel((int)((Sys.tem.Windows.FrameworkElement)sender).Tag);
        }
        public void NoOfProductsSelected(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count>0)
            {
                totalAmount = 0;
                foreach (var i in addedProducts)
                {
                    totalAmount = totalAmount + (i.Value * i.SelectedItemCount);
                }
                var obj = addedProducts.FindLast(x => x.ID == (int)((System.Windows.FrameworkElement)sender).Tag);
                var index = addedProducts.IndexOf(obj);
                addedProducts[index].SelectedItemCount = (int)e.AddedItems[0];
                totalAmountText.Text = totalAmount.ToString();
            }

        }
        public void AddCart(List<AddedProduct> obj)
        {
            CartProducts.ItemsSource = null;
            CartProducts.ItemsSource = obj;

        }

        private void PlaceOrder(object sender, RoutedEventArgs e)
        {
            foreach (AddedProduct productObject in addedProducts)
            {
                if (productObject.ItemsLeft != productObject.SelectedItemCount)
                {
                    var totalItemsLeft = App._Products.First(x => x.ID == productObject.ID).ItemsLeft - productObject.SelectedItemCount;
                    App._Products.First(x => x.ID == productObject.ID).ItemsLeft = totalItemsLeft;
                    addedProducts = new List<AddedProduct>();
                    AddCart(addedProducts);
                }
                else
                {
                    Btn_Delete_Click(productObject.ID);
                    addedProducts = new List<AddedProduct>();
                    AddCart(addedProducts);
                }
                totalAmount = 0;
            }
        }
        public void Btn_Delete_Click(int id)
        {
            Product prodObj = App._Products.First(x => x.ID == id);
            App._Products.Remove(prodObj);
            showingProducts.Remove(prodObj);
            ListViewProducts.ItemsSource = showingProducts;
        }

        private void giftSearchForAdd(object sender, SelectionChangedEventArgs e)
        {

            if (e.AddedItems.Contains("Him"))
            {
                giftFor = "Him";
                DataContext = new ComboBoxViewModel("Him");
            }
            else if (e.AddedItems.Contains("Her"))
            {
                giftFor = "Her";
                DataContext = new ComboBoxViewModel("Her");
            }
            else if (e.AddedItems.Contains("Teen -> boy"))
            {
                giftFor = "Teen -> boy";
                DataContext = new ComboBoxViewModel("Teen -> boy");
            }
            else if (e.AddedItems.Contains("Teen -> girl"))
            {
                giftFor = "Teen -> girl";
                DataContext = new ComboBoxViewModel("Teen -> girl");
            }
            else if (e.AddedItems.Contains("Kids -> boy"))
            {
                giftFor = "Kids -> boy";
                DataContext = new ComboBoxViewModel("Kids -> boy");
            }
            else if (e.AddedItems.Contains("Kids -> girl"))
            {
                giftFor = "Kids -> girl";
                DataContext = new ComboBoxViewModel("Kids -> girl");
            }
            else if (e.AddedItems.Contains("Baby -> boy"))
            {
                giftFor = "Baby -> boy";
                DataContext = new ComboBoxViewModel("Baby -> boy");
            }
            else
            {
                giftFor = "Baby -> girl";
                DataContext = new ComboBoxViewModel("Baby -> girl");
            }
        }
        private void SortByPrice(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                sortBy = e.AddedItems[0].ToString();
                if (e.AddedItems[0].ToString().Contains("Price -> Low"))
                {
                    showingProducts = new ObservableCollection<Product>(showingProducts.OrderBy(x => x.Value));
                }
                else
                {
                    showingProducts = new ObservableCollection<Product>(showingProducts.OrderByDescending(x => x.Value));
                }
            }
            ListViewProducts.ItemsSource = showingProducts;
        }

        private void ChangeLanguage(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
