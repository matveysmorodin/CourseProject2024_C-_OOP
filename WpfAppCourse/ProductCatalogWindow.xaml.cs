using System.Collections.ObjectModel;
using System.Windows;

namespace CourseProject
{
    public partial class ProductCatalogWindow : Window
    {
        public static ObservableCollection<string> Products { get; set; } = new ObservableCollection<string>();

        public ProductCatalogWindow()
        {
            InitializeComponent();
            listBoxProducts.ItemsSource = Products;
        }

        public static void AddProduct(string name, string price)
        {
            Products.Add($"{name} - ₽{price}");
        }

        public static void RemoveProduct(string name)
        {
            var productToRemove = Products.FirstOrDefault(p => p.StartsWith(name));
            if (productToRemove != null)
            {
                Products.Remove(productToRemove);
            }
        }
    }
}
