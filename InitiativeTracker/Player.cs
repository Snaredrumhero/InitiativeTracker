using System;

namespace InitiativeTracker
{
    public class Player : ICombatant
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


        public required int Initiative { get; set; }
        public required int CurrentHealth { get; set; }
        public required int TemporaryHealth { get; set; }
        public required int MaxHealth { get; init; }
        public required int ArmorClass { get; set; }
        public bool IsActionHeld { get; set; }
        public bool IsConcentrating { get; set; }
        public string? AdditionalStateInformation { get; set; }
        public required string Name { get; set; }
        public string? Notes { get; set; }
        public int Damage(int hp)
        {
            throw new NotImplementedException();
        }

        public int Heal(int hp)
        {
            throw new NotImplementedException();
        }

        public int GainTemporaryHealth(int hp)
        {
            throw new NotImplementedException();
        }
    }
}
