
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]
public class EnemyCharacter : BaseCharacter , IDiable
{

    [Space(3)]
    [Header("Health Settings")]
    public HealthStats healthStats;


  public override HealthStats GetHealthStats()
    {
        return healthStats;
    }

}