using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                DisplayTextBox.Text += b.Content.ToString();
            }
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                var op = b.Content.ToString();
                // add spaces around operators for readability
                DisplayTextBox.Text += " " + op + " ";
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayTextBox.Text = string.Empty;
        }

        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            var text = DisplayTextBox.Text;
            if (!string.IsNullOrEmpty(text))
            {
                DisplayTextBox.Text = text.Substring(0, text.Length - 1);
            }
        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayTextBox.Text += ".";
        }

        private void SignChangeButton_Click(object sender, RoutedEventArgs e)
        {
            var text = DisplayTextBox.Text;
            if (string.IsNullOrEmpty(text))
            {
                DisplayTextBox.Text = "-";
                return;
            }

            if (text.StartsWith("-"))
                DisplayTextBox.Text = text.Substring(1);
            else
                DisplayTextBox.Text = "-" + text;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var expr = DisplayTextBox.Text.Replace("×", "*").Replace("÷", "/");
                var dt = new DataTable();
                var result = dt.Compute(expr, string.Empty);
                DisplayTextBox.Text = result.ToString();
            }
            catch
            {
                // on error, do nothing or clear
                DisplayTextBox.Text = "Error";
            }
        }
    }
}