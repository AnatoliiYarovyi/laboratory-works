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

namespace pounds_kilograms
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

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedUnit = ((ComboBoxItem)unitSelector.SelectedItem).Content.ToString();
            double inputValue;

            if (double.TryParse(inputBox.Text, out inputValue))
            {
                double result = ConvertWeight(inputValue, selectedUnit);
                resultText.Text = $"Результат: {result:F2} {(selectedUnit == "Фунти" ? "Кілограмів" : "Фунтів")}";
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть коректне число.");
            }
        }

        private double ConvertWeight(double value, string unit)
        {
            if (unit == "Фунти")
            {
                return value * 0.453592; 
            }
            else
            {
                return value / 0.453592;
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            inputBox.Clear();
            resultText.Text = string.Empty;
        }
    }
}