
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class Character : MonoBehaviour
{
    public CharacterStats stats = new CharacterStats();

    public Transform target;

    #region Change Stats Mehods
    public virtual void TakeDamage(float amount)
    {
        if (amount > 0)
            stats.healthStats.Health -= amount;
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

        Destroy(gameObject);
    }
}