using System;
using System.Windows;

namespace CourseProject
{
    public partial class UserProfileWindow : Window
    {
        public UserProfileWindow()
        {
            InitializeComponent();
            Random random = new Random();
            lblID.Text = "ID: " + random.Next(1, 1000).ToString();
            lblName.Text = "Имя: Матвей Смородин";
            lblBalance.Text = "Баланс: ₽" + random.Next(100, 1000).ToString();
        }
    }
}
