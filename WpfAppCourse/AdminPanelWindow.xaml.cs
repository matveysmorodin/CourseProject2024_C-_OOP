using System.Windows;

namespace CourseProject
{
    public partial class AdminPanelWindow : Window
    {
        public AdminPanelWindow()
        {
            InitializeComponent();
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            string productName = txtProductName.Text;
            string productPrice = txtProductPrice.Text;
            if (!string.IsNullOrWhiteSpace(productName) && !string.IsNullOrWhiteSpace(productPrice))
            {
                ProductCatalogWindow.AddProduct(productName, productPrice);
                MessageBox.Show("Товар успешно добавлен!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                txtProductName.Clear();
                txtProductPrice.Clear();
            }
            else
            {
                MessageBox.Show("Пожалуйста, вставте цену и товар!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            string productName = txtProductName.Text;
            if (!string.IsNullOrWhiteSpace(productName))
            {
                ProductCatalogWindow.RemoveProduct(productName);
                MessageBox.Show("Товар удален успешно!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                txtProductName.Clear();
            }
            else
            {
                MessageBox.Show("Пожалуйста укажите название товара для удаления!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
