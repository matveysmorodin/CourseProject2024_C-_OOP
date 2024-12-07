using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using CourseProject;

namespace CourseProject
{
    public partial class ProductCatalogWindow : Window
    {
        private readonly string _filePath = "products.json";
        public static ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        public ProductCatalogWindow()
        {
            InitializeComponent();
            LoadProducts();
            listBoxProducts.ItemsSource = Products;
        }

        private void LoadProducts()
        {
            // Загружаем продукты из файла
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                var loadedProducts = JsonSerializer.Deserialize<ObservableCollection<Product>>(json);
                if (loadedProducts != null)
                {
                    Products.Clear();
                    foreach (var product in loadedProducts)
                    {
                        Products.Add(product);
                    }
                }
            }
        }

        private static void SaveProductsStatic()
        {
            var json = JsonSerializer.Serialize(Products, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("products.json", json);
        }

        public static void AddProduct(string name, string price)
        {
            if (decimal.TryParse(price, out var parsedPrice))
            {
                Products.Add(new Product { Name = name, Price = parsedPrice });
                SaveProductsStatic();
            }
            else
            {
                MessageBox.Show("Некорректная цена!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void RemoveProduct(string name)
        {
            var productToRemove = Products.FirstOrDefault(p => p.Name == name);
            if (productToRemove != null)
            {
                Products.Remove(productToRemove);
                SaveProductsStatic();
            }
            else
            {
                MessageBox.Show("Продукт не найден!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Name} - ₽{Price:F2}";
        }
    }
}
