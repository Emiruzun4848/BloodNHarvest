
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class BaseCharacter : MonoBehaviour, IDiable,IDamagable, IHealthSystem
{
    [Header("BaseCharacter Settings")]
    public BaseCharacter mycharacter;
    public CharacterStats stats;
    public BaseCharacter target;

    
    #region Change Stats Mehods
    public virtual void TakeDamage(float damage, AttackPower attackPower, PenetrationStats penetrationStats)
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
        GetHealthStats().Health -= newDamage;
        Debug.Log($"{gameObject.name} took {newDamage} damage. Remaining Health: {GetHealthStats().Health}");
        if (GetHealthStats().Health <= 0.1f)
        {
            BeforeDie();
        }
    
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


    /// <summary>
    /// Ölmeden Önceki Ýþlemler;
    /// Örneðin: Ölmeden Önce Kalkan Gibisinden eklenebilir, Sýnýrlý süre hayatta kalma gibi faktörler için kullanabiliriz.
    /// </summary>
    public virtual void BeforeDie()
    {

        Die();
    }

    /// <summary>
    /// Ölüm Anýnda Ýþlemler;
    /// Örneðin: Ekstra Can Gibi Ýþlemler.
    /// </summary>
    public virtual void Die()
    {

        AfterDie();
    }
    /// <summary>
    /// Ölüm Anýnda Ýþlemler;
    /// Örneðin: iþlemler.
    /// </summary>
    public virtual void AfterDie()
    {
        Debug.Log($"{gameObject.name} has died.");
        Destroy(gameObject);
    }

    public virtual HealthStats GetHealthStats()
    {
        return new HealthStats();
    }
}