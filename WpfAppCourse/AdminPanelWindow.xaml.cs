using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;

namespace CourseProject
{
    public partial class AdminPanelWindow : Window
    {
        private ObservableCollection<Product> _products;
        private Product _selectedProduct;
        private readonly string _filePath = "products.json";

        public AdminPanelWindow()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            // Загружаем товары из файла
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                _products = JsonSerializer.Deserialize<ObservableCollection<Product>>(json) ?? new ObservableCollection<Product>();
            }
            else
            {
                _products = new ObservableCollection<Product>();
            }

            dataGridProducts.ItemsSource = _products;
        }

        private void SaveProducts()
        {
            // Сохраняем товары в файл
            var json = JsonSerializer.Serialize(_products);
            File.WriteAllText(_filePath, json);
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtProductName.Text) && decimal.TryParse(txtProductPrice.Text, out var price))
            {
                var product = new Product { Name = txtProductName.Text, Price = price };
                _products.Add(product);
                SaveProducts();
                txtProductName.Clear();
                txtProductPrice.Clear();
            }
            else
            {
                MessageBox.Show("Введите корректные данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedProduct != null)
            {
                _products.Remove(_selectedProduct);
                SaveProducts();
                txtProductName.Clear();
                txtProductPrice.Clear();
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedProduct != null && !string.IsNullOrWhiteSpace(txtProductName.Text) && decimal.TryParse(txtProductPrice.Text, out var price))
            {
                _selectedProduct.Name = txtProductName.Text;
                _selectedProduct.Price = price;
                SaveProducts();
                dataGridProducts.Items.Refresh();
                txtProductName.Clear();
                txtProductPrice.Clear();
            }
            else
            {
                MessageBox.Show("Выберите товар и введите корректные данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dataGridProducts_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _selectedProduct = (Product)dataGridProducts.SelectedItem;
            if (_selectedProduct != null)
            {
                txtProductName.Text = _selectedProduct.Name;
                txtProductPrice.Text = _selectedProduct.Price.ToString();
            }
        }
    }

    public class Product1
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
