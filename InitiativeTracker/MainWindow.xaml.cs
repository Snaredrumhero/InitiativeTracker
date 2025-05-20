using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace InitiativeTracker
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Player> Players = new List<Player>();
        public Stack<UndoData> UndoStack;

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
            // TODO Check if initiative has changed between the grid and the objects. If so, refresh grid

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


            // Testing Undo Stack
            List<CombatantUndo> UndoPlayersList = new List<CombatantUndo>;
            foreach (Player player in Players) 
            {
                if (player == null)
                {
                    continue;
                }
                CombatantUndo data = new CombatantUndo(player.Initiative, player.MaxHealth, player.TemporaryHealth, false, false);
                UndoPlayersList.Add(data);
            }
            UndoData undoData = new UndoData(UndoPlayersList, 1, 3);
            UndoStack.Push(undoData);



            RefreshGrid();
            // TODO Display new players
        }
        // Reads updated initiative, changes respective player objects and refreshes grid
        private void RefreshButton_OnClick(object sender, RoutedEventArgs e)
        {
            RefreshGrid();
            //TODO Display new players
        }
        // Reorders players in list, removes all existing values, creates new grid to store them in
        private void RefreshGrid()
        {
            //Clear existing values
            // https://learn.microsoft.com/en-us/dotnet/desktop/wpf/controls/manipulate-columns-and-rows-by-using-columndefinitionscollections?view=netframeworkdesktop-4.8
            //Compute required rows
            int numCols = (Players.Count / 7) + 1;
            

            //Create needed rows and populate with controls
            //Set all unused rows and controls to be invisible and disabled
            //Loop over rows and populate data
            throw new NotImplementedException();
            
        }
        // Highlight the player whose turn it is
        private void HighlightPlayer()
        {
            throw new NotImplementedException();
        }

        private void UndoButton_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void ApplyDamageButton_OnClick(object sender, RoutedEventArgs e)
        {
            // TODO Apply damage to all selected players
        }

    }
    