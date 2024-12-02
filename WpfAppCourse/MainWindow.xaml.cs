using System.Windows;

namespace CourseProject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPersonalAccount_Click(object sender, RoutedEventArgs e)
        {
            PersonalAccountWindow personalAccountWindow = new PersonalAccountWindow();
            personalAccountWindow.ShowDialog();
        }

        private void btnProductCatalog_Click(object sender, RoutedEventArgs e)
        {
            ProductCatalogWindow productCatalogWindow = new ProductCatalogWindow();
            productCatalogWindow.ShowDialog();
        }

        private void btnAdminPanel_Click(object sender, RoutedEventArgs e)
        {
            AdminPanelWindow adminPanelWindow = new AdminPanelWindow();
            adminPanelWindow.ShowDialog();
        }
    }
}
