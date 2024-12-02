using System.Windows;

namespace CourseProject
{
    public partial class PersonalAccountWindow : Window
    {
        public PersonalAccountWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text == "admin" && txtPassword.Text == "admin")
            {
                MessageBox.Show("Вход успешен, добро пожаловать!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                // Show user profile
                UserProfileWindow userProfileWindow = new UserProfileWindow();
                userProfileWindow.Show();
                // Close the login window
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
