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
    public bool DealDamage { get; set; } = false;
    public string? AdditionalStateInformation { get; set; }
    public required string Name { get; set; }
    public string? Notes { get; set; }
    public int Damage(int hp)
    {
        if (hp < 0) hp = 0; // Only track negative damage for a single attack, not cumulative damage

        if (hp < TemporaryHealth) // Damage only hits temporary health
        {
            TemporaryHealth -= hp;
            throw new NotImplementedException();
            return 0; // No damage to current health
        }
        hp -= TemporaryHealth; // Reduce damage by temporary health
        CurrentHealth -= hp;
        TemporaryHealth = 0;
        throw new NotImplementedException();
        return hp; // Return the amount of damage dealt to current health
    }

    public int Heal(int hp)
    {
        if (CurrentHealth + hp >= MaxHealth)
        {
            hp = MaxHealth - CurrentHealth; // Heal only up to max health
            CurrentHealth = MaxHealth;
            throw new NotImplementedException();
            return hp;
        }
        CurrentHealth += hp;
        throw new NotImplementedException();
        return hp; // Return the amount healed
    }

    public int GainTemporaryHealth(int hp)
    {
        TemporaryHealth += hp;
        throw new System.NotImplementedException();
    }
}