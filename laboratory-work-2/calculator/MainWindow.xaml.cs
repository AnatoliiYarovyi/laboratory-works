using System.Data;
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

namespace calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach(UIElement el in MainRoot.Children)
            {
                if(el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;

            switch (str)
            {
                case "C":
                    textResults.Text = "";
                    textLablel.Text = "";
                    break;

                case "=":
                    CalculateExpression();
                    break;

                case "<":
                    if (textLablel.Text.Length > 0)
                    {
                        textLablel.Text = textLablel.Text.Remove(textLablel.Text.Length - 1);
                    }
                    break;

                case "CE":
                    textLablel.Text = "";
                    break;

                case ".":
                    if (!textLablel.Text.Contains("."))
                    {
                        textLablel.Text += str;
                    }
                    break;

                case "+":
                case "-":
                case "*":
                case "/":
                    HandleOperatorButton(str);
                    break;

                default:
                    textLablel.Text += str;
                    break;
            }
        }

        private void CalculateExpression()
        {
            try
            {
                string value = new DataTable().Compute(textLablel.Text, null).ToString();
                textResults.Text = textLablel.Text;
                textLablel.Text = value;
            }
            catch (SyntaxErrorException)
            {
                textResults.Text = "Error";
                textLablel.Text = "";
            }
        }

        private void HandleOperatorButton(string operatorSymbol)
        {
            if (textLablel.Text.Length > 0)
            {
                char lastChar = textLablel.Text[textLablel.Text.Length - 1];

                if (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/')
                {
                    // Replace the last operator with the new one
                    textLablel.Text = textLablel.Text.Remove(textLablel.Text.Length - 1) + operatorSymbol;
                }
                else
                {
                    // Append the new operator
                    textLablel.Text += operatorSymbol;
                }
            }
        }
    }
}