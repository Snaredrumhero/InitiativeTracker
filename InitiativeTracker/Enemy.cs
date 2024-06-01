using System;

namespace InitiativeTracker;

public class Enemy : ICombatant
{
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
        throw new System.NotImplementedException();
    }

    public int Heal(int hp)
    {
        throw new System.NotImplementedException();
    }

    public int GainTemporaryHealth(int hp)
    {
        throw new System.NotImplementedException();
    }
}