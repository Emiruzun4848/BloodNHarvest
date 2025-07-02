using UnityEngine;

[System.Serializable]
public class CharacterStats
{

    [Header("Speed Settings")]
    public SpeedStats speedStats;

    [Header("Penetration Stats")]
    public PenetrationStats penetrationStats;

    [Header("Defense Settings")]
    public DefenseStats defenseStats;
}
