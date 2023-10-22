using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    public class Player
    {
        public Player(int constructInitiative = 0, int constructMaxHealth = 0, int constructArmorClass = 0, 
            string constructName = "", string constructNotes = "")
        {
            Initiative = constructInitiative;
            CurrentHealth = constructMaxHealth;
            MaxHealth = constructMaxHealth;
            ArmorClass = constructArmorClass;
            Name = constructName;
            Notes = constructNotes;
        }
        
        public int Initiative;
        public int CurrentHealth;
        public int MaxHealth;
        public int ArmorClass;
        public string Name;
        public string Notes;
    }
}
