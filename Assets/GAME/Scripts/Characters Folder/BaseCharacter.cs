
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
    /// �lmeden �nceki ��lemler;
    /// �rne�in: �lmeden �nce Kalkan Gibisinden eklenebilir, S�n�rl� s�re hayatta kalma gibi fakt�rler i�in kullanabiliriz.
    /// </summary>
    public virtual void BeforeDie()
    {

        Die();
    }

    /// <summary>
    /// �l�m An�nda ��lemler;
    /// �rne�in: Ekstra Can Gibi ��lemler.
    /// </summary>
    public virtual void Die()
    {

        AfterDie();
    }
    /// <summary>
    /// �l�m An�nda ��lemler;
    /// �rne�in: i�lemler.
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