using System;
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

namespace game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            private List<Button> allButtons;

            public MainWindow()
            {
                InitializeComponent();

                allButtons = new List<Button>
            {
                Button1, Button2, Button3, Button4, Button5
            };

                foreach (Button button in allButtons)
                {
                    button.Click += Button_Click;
                }
            }

            private void Button_Click(object sender, RoutedEventArgs e)
            {
                // Shuffle the buttons randomly
                List<Button> shuffledButtons = allButtons.OrderBy(x => Guid.NewGuid()).ToList();

                // Calculate how many buttons to hide and show
                int buttonsToHideCount = new Random().Next(1, allButtons.Count);
                int buttonsToShowCount = allButtons.Count - buttonsToHideCount;

                // Hide buttons
                for (int i = 0; i < buttonsToHideCount; i++)
                {
                    shuffledButtons[i].Visibility = Visibility.Collapsed;
                }

                // Show buttons
                for (int i = buttonsToHideCount; i < allButtons.Count; i++)
                {
                    shuffledButtons[i].Visibility = Visibility.Visible;
                }

                // Check if all buttons are hidden
                bool allButtonsHidden = allButtons.All(button => button.Visibility == Visibility.Collapsed);

                // If all buttons are hidden, show a message and reset the game
                if (allButtonsHidden)
                {
                    MessageBox.Show("You win!!! You have hidden all the buttons!!");
                    ResetGame();
                }
            }

            private void ResetGame()
            {
                // Reset the visibility of all buttons to Visible
                foreach (Button button in allButtons)
                {
                    button.Visibility = Visibility.Visible;
                }
            }
        }
}