
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Splines;

public abstract class CharacterPlus : BaseCharacter, IRegenable, IHealable
{
    [Space(3)]
    [Header("Character Plus Settings")]
    public HealthStatsPLus healthStats;
    public ManaStats manaStats;

    public bool isAlive = true;
    public bool canRegen = true; // Can the character regenerate health and mana
    protected virtual void Update()
    {
        AutoRegen();
    }
    protected virtual void AutoRegen()
    {
        if (isAlive & canRegen)
        {
            RegenerateHealth();
            RegenerateMana();
        }
    }
    public void RegenerateHealth()
    {
        if (isAlive & canRegen)
        {
            healthStats.Health += healthStats.Regen * Time.deltaTime;
        }
    }

    public void RegenerateMana()
    {
        if (isAlive & canRegen)
        {
            manaStats.Mana += manaStats.Regen * Time.deltaTime;
        }
    }

    #region Change Stats Mehods
    public override void TakeDamage(float damage, AttackPower attackPower, PenetrationStats penetrationStats)
    {
        float tot, totPercent;
        if (attackPower == AttackPower.Physical)
        {
            tot = stats.defenseStats.TotalArmor - penetrationStats.ArmorPenetration;
            totPercent = stats.defenseStats.TotalArmorPercent - penetrationStats.ArmorPenetrationPercent;
        }
        else
        {
            tot = stats.defenseStats.TotalMagicResist - penetrationStats.MagicPenetration;
            totPercent = stats.defenseStats.TotalMagicResistPercent - penetrationStats.MagicPenetrationPercent;
        }
        tot = Mathf.Max(0, tot);
        totPercent = Mathf.Max(0, totPercent);
        float newDamage = damage * (100 - totPercent) / 100;
        newDamage -= tot;
        newDamage = Mathf.Max(0, newDamage);
        healthStats.Health -= newDamage;
        Debug.Log($"{gameObject.name} took {newDamage} damage. Remaining Health: {healthStats.Health}");
        if (healthStats.Health <= 0.1f)
        {
            BeforeDie();
        }
    }
    public virtual void IncreaseMana(float amount)
    {
        if (amount > 0)
            manaStats.Mana += amount;
    }
    public virtual void DecreaseMana(float amount)
    {
        if (amount > 0)
            manaStats.Mana -= amount;
    }

    public void Heal(float amount)
    {
        if (isAlive)
        {
            healthStats.Health += amount;
        }
    }
    public override HealthStats GetHealthStats()
    {
        return healthStats;
    }
    public bool CanBeHealed() => healthStats.Health < healthStats.MaxHealth && isAlive;
    #endregion


}