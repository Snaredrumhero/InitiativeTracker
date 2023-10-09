using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    internal class Player
    {
        public Player(int constructInitiative, int constructMaxHealth, int constructArmorClass, 
            string constructName, string constructNotes)
        {
            initiative = constructInitiative;
            current_health = constructMaxHealth;
            max_health = constructMaxHealth;
            armor_class = constructArmorClass;
            name = constructName;
            notes = constructNotes;
        }

        public Player()
        {
            initiative = -1;
            current_health = 0;
            max_health = 0;
            armor_class = 0;
            name = "Enemy 1";
            notes = "";
        }


        private int initiative;
        private int current_health;
        private int max_health;
        private int armor_class;
        private string name;
        private string notes;
    }
}
