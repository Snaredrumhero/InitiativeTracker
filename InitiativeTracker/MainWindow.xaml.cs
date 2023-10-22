using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        public List<Player> Players = new List<Player>();

        public MainWindow()
        {
            InitializeComponent();
            // Before I see the window
            // Additional code is below me!
        }

        private void NextTurn_Button_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is not Button b)
            {
                throw new Exception("Fuck!");
            }
            b.Background = Brushes.Yellow;
            TotalTurnsLabel.Content = "Round";

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Player testPlayer = new ();
            //Player testPlayer2 = new (5, 5, 5, "Candace", "Tech Specialist");
            //Player testPlayer3 = new (10, 10, 10, "Kang", "Monk Goliath");
            //Player testPlayer4 = new (15, 15, 15, "Drew Mullett", "Fucking crazy");
            //List<Player> testPlayers = new() { testPlayer, testPlayer2, testPlayer3, testPlayer4 };

            //string jsonString = JsonConvert.SerializeObject(testPlayers, Formatting.Indented);
            //File.WriteAllText("test.json", jsonString);

            //When I see the window (after it appears, this runs)
        }

        private void LoadButton_OnClick(object sender, RoutedEventArgs e)
        {
            // Open file explorer window
            OpenFileDialog fileDialog = new()
            {
                Filter = "Json Files (*.json)|*.json|All Files (*.*)|*.*",
                Title = "Select json file"
            };
            // Check if a file was selected
            if (fileDialog.ShowDialog() is not true)
            {
                return;
            }

            string jsonString = File.ReadAllText(fileDialog.FileName);
            List<Player> loadedPlayers = JsonConvert.DeserializeObject<List<Player>>(jsonString) ?? throw new Exception("Invalid json file");
            // TODO Error handling
            Players.AddRange(loadedPlayers);

            RefreshGrid();
            //TODO Display new players
        }

        private void RefreshButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void RefreshGrid()
        {
            throw new NotImplementedException();
            
        }
    }   
        
}
    