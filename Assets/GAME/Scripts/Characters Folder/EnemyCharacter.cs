
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]
public class EnemyCharacter : BaseCharacter , IDiable
{

    [Space(3)]
    [Header("Health Settings")]
    public HealthStats healthStats;

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
    #endregion

  public override HealthStats GetHealthStats()
    {
        return healthStats;
    }

}