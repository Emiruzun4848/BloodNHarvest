using UnityEngine;

[System.Serializable]
public class HealthStats
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float health = 100f;
    [SerializeField] private float regen = 0.2f;
    public float MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }
    public float Health
    {
        get { return health; }
        set { health = Mathf.Clamp(value, 0, MaxHealth); }
    }
    public float Regen
    {
        get { return regen; }
        set { regen = value; }
    }

}

[System.Serializable]
public class ManaStats
{
    [SerializeField] private float maxMana = 300f;
    [SerializeField] private float mana = 30f;
    [SerializeField] private float regen = 0.5f;
    public float MaxMana
    {
        get { return maxMana; }
        set { maxMana = value; }
    }
    public float Mana
    {
        get { return mana; }
        set { mana = Mathf.Clamp(value, 0, MaxMana); }
    }
    public float Regen
    {
        get { return regen; }
        set { regen = value; }
    }
}
[System.Serializable]
public class SpeedStats
{
    [SerializeField] private float baseSpeed = 5f;
    [SerializeField] private float speed = 5f;
    public float BaseSpeed
    {
        get { return baseSpeed; }
        set { baseSpeed = value; }
    }
    public float Speed
    {
        get { return speed; }
        set { speed = Mathf.Clamp(value,0,float.MaxValue); }
    }
}
[System.Serializable]
public class CharacterStats
{
    [Header("Variables")]
    #region Variables
    public bool isAlive = true;

    [Header("Health Settings")]
    public HealthStats healthStats;

    [Header("Mana Settings")]
    public ManaStats manaStats;

    [Header("Speed Settings")]
    public SpeedStats speedStats;

    #endregion

}