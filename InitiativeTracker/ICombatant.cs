namespace InitiativeTracker
{
    public interface ICombatant
    {
        public int Initiative { get; set; }
        public int CurrentHealth { get; set; }
        public int TemporaryHealth { get; set; }
        public int MaxHealth { get; init; }
        public int ArmorClass { get; set; }
        public bool IsActionHeld { get; set; }
        public bool IsConcentrating { get; set; }
        public bool DealDamage { get; set; }
        public string? AdditionalStateInformation { get; set; }

        public string Name { get; }
        public string? Notes { get; set; }

        public int Damage(int hp);
        public int Heal(int hp);
        public int GainTemporaryHealth(int hp);
    }
}
