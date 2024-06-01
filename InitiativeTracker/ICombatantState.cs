namespace InitiativeTracker;

public interface ICombatantState
{
    public int Initiative { get; set; }
    public int CurrentHealth { get; set; }
    public int TemporaryHealth { get; set; }
    public int MaxHealth { get; init; }
    public int ArmorClass { get; set; }
    public bool IsActionHeld { get; set; }
    public bool IsConcentrating { get; set; }
    public string? AdditionalStateInformation { get; set; }
}