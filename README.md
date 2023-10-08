# InitiativeTracker
C# App with WPF GUI to track PC and enemy AC, Hit Points, ability notes, and the ability to change initiative mid combat

# Required Features
* Player Information
  * Center subgrid, can hold up to 15 slots (5 players and 10 enemies)
  * Holds HP, AC, initiative value, character name
  * Open file button which allows you to point to a json file of characters you want to put in
* Refresh
  * Updates initiative order
  * Highlights player next lowest in initiative order
* Next turn button
  * Highlights the next player in turn order
  * If it gets to the end of the list, it will check if anyone has held their action and make a pop up asking if the user want's to continue anyways
