
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