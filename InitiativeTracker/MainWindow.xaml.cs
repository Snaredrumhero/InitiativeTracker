using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InitiativeTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Before I see the window
            // Additional code is below me!
        }

        private void Refresh_Button_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is not Button b)
            {
                throw new Exception("Fuck!");
            }

            b.Background = Brushes.Yellow;
            
        }

        private void InstructionTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            InstructionTextBox.Background = Brushes.Aqua;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            //When I see the window (after it appears, this runs)
        }
    }
}
