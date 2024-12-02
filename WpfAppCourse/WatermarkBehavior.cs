using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace CourseProject
{
    public class WatermarkBehavior : Behavior<TextBox>
    {
        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.Register("Watermark", typeof(string), typeof(WatermarkBehavior), new PropertyMetadata(null));

        public string Watermark
        {
            get { return (string)GetValue(WatermarkProperty); }
            set { SetValue(WatermarkProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.GotFocus += OnGotFocus;
            AssociatedObject.LostFocus += OnLostFocus;
            UpdateWatermark();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.GotFocus -= OnGotFocus;
            AssociatedObject.LostFocus -= OnLostFocus;
        }

        private void OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (AssociatedObject.Text == Watermark)
            {
                AssociatedObject.Text = string.Empty;
                AssociatedObject.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void OnLostFocus(object sender, RoutedEventArgs e)
        {
            UpdateWatermark();
        }

        private void UpdateWatermark()
        {
            if (string.IsNullOrWhiteSpace(AssociatedObject.Text))
            {
                AssociatedObject.Text = Watermark;
                AssociatedObject.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
    }
}
