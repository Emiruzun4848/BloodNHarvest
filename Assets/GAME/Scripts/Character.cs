
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class Character : MonoBehaviour
{
    public CharacterStats stats = new CharacterStats();

    public Character target;

    #region Change Stats Mehods
    public virtual void TakeDamage(float damage,AttackPower attackPower,PenetrationStats penetrationStats)
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
        float newDamage = damage*(100-totPercent)/100;
        newDamage -= tot;
        newDamage = Mathf.Max(0, newDamage);
        stats.healthStats.Health -= newDamage;
        if (stats.healthStats.Health <= 0)
        {
            BeforeDie();
        }
    }
    public virtual void Heal(float amount)
    {
        if (amount > 0)
            stats.healthStats.Health += amount;
    }

    public virtual void IncreaseMana(float amount)
    {
        if (amount > 0)
            stats.manaStats.Mana += amount;
    }

    public virtual void DecreaseMana(float amount)
    {
        if (amount > 0)
            stats.manaStats.Mana -= amount;
    }

    public virtual void IncreaseSpeed(float amount)
    {
        if (amount > 0)
            stats.speedStats.Speed += amount;
    }
    public virtual void DecreaseSpeed(float amount)
    {
        if (amount > 0)
            stats.speedStats.Speed -= amount;
    }
    #endregion

    protected virtual void Update()
    {
        
        AutoRegen();
    }
    void AutoRegen()
    {
        Heal(stats.healthStats.Regen* Time.deltaTime);
        IncreaseMana(stats.manaStats.Regen* Time.deltaTime);
    }
    /// <summary>
    /// Ölmeden Önceki İşlemler;
    /// Örneğin: Ölmeden Önce Kalkan Gibisinden eklenebilir, Sınırlı süre hayatta kalma gibi faktörler için kullanabiliriz.
    /// </summary>
    protected virtual void BeforeDie()
    {

        Die();
    }

    /// <summary>
    /// Ölüm Anında İşlemler;
    /// Örneğin: Ekstra Can Gibi İşlemler.
    /// </summary>
    protected virtual void Die()
    {

        AfterDie();
    }
    /// <summary>
    /// Ölüm Anında İşlemler;
    /// Örneğin: işlemler.
    /// </summary>
    protected virtual void AfterDie()
    {
        Debug.Log($"{gameObject.name} has died.");
        Destroy(gameObject);
    }
}