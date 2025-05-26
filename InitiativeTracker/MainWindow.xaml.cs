using Avalonia.Media.Immutable;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace InitiativeTracker;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public List<Player> Players = new List<Player>();
    public List<Enemy> Enemies = new List<Enemy>();
    public Combat? CurrentCombat;

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
            throw new Exception("A different object accessed NextTurn_Button_OnClick");
        }
        if (b.Content.ToString() == "Start" || CurrentCombat is null)
        {
            // TODO: Automatically roll any initiative for Enemies and NPC labeled Players
            CurrentCombat = new Combat(Players, Enemies);
            b.Content = "Next Turn";
        }
        else
        {
            if (!CurrentCombat.TryMoveNext()) return; // If the move failed, exit the method

            TotalTurnsLabel.Content = "Round " + CurrentCombat.CurrentState.Turn;
            HighlightPlayer(); // Highlight the player(s) whose turn it is
            RefreshGrid(); 

        }
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

    private void LoadPlayersButton_OnClick(object sender, RoutedEventArgs e)
    {
        // TODO Open window to ask if you're loading players or enemies

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
        // TODO Display new players
    }
    private void LoadNPCButton_OnClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
    private void CreateCustomCombatantButton_OnClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
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
        if (CurrentCombat is null) return; // Ensure CurrentCombat is initialized
        throw new NotImplementedException();
    }

    private void UndoButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (CurrentCombat is null) return; // Ensure CurrentCombat is initialized
        CurrentCombat.Undo();
        RefreshGrid();
    }

    private void ApplyDamageButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (CurrentCombat is null) return; // Ensure CurrentCombat is initialized
        // TODO Apply damage to all selected players
        if (int.TryParse(DamageTextBox.Text, out int damage))
        {
            CurrentCombat.DealDamage(damage);
            RefreshGrid();
        }
        else
        {
            MessageBox.Show("Please enter a valid number for damage.");
        }
    }

    private void DamageTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if (CurrentCombat is null) return; // Ensure CurrentCombat is initialized
        if (e.Key == System.Windows.Input.Key.Enter)
        {
            // Get the text from the TextBox and parse it as an integer
            if (sender is TextBox tb && int.TryParse(tb.Text, out int damage))
            {
                // Apply damage logic here
                CurrentCombat.DealDamage(damage);
                RefreshGrid();
            }
            else
            {
                MessageBox.Show("Please enter a valid number for damage.");
            }
        }
    }


}
