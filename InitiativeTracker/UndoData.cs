using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    public class UndoData
    {
        // List of what needs to be stored to remake the game
        // List of players and enemies (HP, Temp HP, Max HP?, Initiative, Action Held, Concentrating) ID for each combatant???
        // -- We need to figure out how to store the combatants in a way that we can reidntify them later
        // Global Initiative
        // Global Turn Counter

        public UndoData(List<CombatantUndo> constructCombatants, int constructCurrentInitiative, int constructGlobalTurnCounter) 
        { 
            Combatants = constructCombatants;
            CurrentInitiative = constructCurrentInitiative;
            GlobalTurnCounter = constructGlobalTurnCounter;
        }

        public UndoData(IEnumerable<ICombatant> constructCombatants, int constructCurrentInitiative, int constructGlobalTurnCounter)
        {
            Combatants = new List<CombatantUndo>();
            foreach (ICombatant combatant in constructCombatants)
            {
                Combatants.Add(new CombatantUndo(combatant.Initiative, combatant.CurrentHealth, combatant.TemporaryHealth, combatant.IsActionHeld, combatant.IsConcentrating, combatant.Name));
            }
            CurrentInitiative = constructCurrentInitiative;
            GlobalTurnCounter = constructGlobalTurnCounter;
        }

        public List<CombatantUndo> Combatants;
        public int CurrentInitiative;
        public int GlobalTurnCounter;

        // Do we need to move initiative back only once or until the next major change?
        // *We should only save when large changes occur and then we'll just pop the stack whenever necessary*
    }
    // Stores the condensed information of all the players
    public class CombatantUndo
    {
        public CombatantUndo(int constructInitiative, int constructCurrentHealth, int constructTemporaryHealth, bool constructIsActionHeld, bool constructIsConcentrating, string constructName) 
        {
            Initiative = constructInitiative;
            CurrentHealth = constructCurrentHealth;
            TemporaryHealth = constructTemporaryHealth;
            IsActionHeld = constructIsActionHeld;
            IsConcentrating = constructIsConcentrating;
            Name = constructName;
        } 
        
        public int Initiative;
        public int CurrentHealth;
        public int TemporaryHealth;
        public bool IsActionHeld;   
        public bool IsConcentrating;
        public string Name;
    }
}
