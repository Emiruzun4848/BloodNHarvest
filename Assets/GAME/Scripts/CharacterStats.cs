using System;
using UnityEngine;



[System.Serializable]
public class HealthStats
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float health = 100f;
    [SerializeField] private float regen = 0.2f;
    public virtual float MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }

    public virtual float Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, float.MinValue, MaxHealth);
        }
    }

    public float Regen
    {
        get => regen;
        set => regen = value;
    }
}
[System.Serializable]
public class ManaStats
{
    [SerializeField] private float maxMana = 100f;
    [SerializeField] private float mana = 100f;
    [SerializeField] private float regen = 0.2f;
    public float MaxMana
    {
        get => maxMana;
        set => maxMana = value;
    }

    public float Mana
    {
        get => mana;
        set => mana = Mathf.Clamp(value, 0, MaxMana);
    }

    public float Regen
    {
        get => regen;
        set => regen = value;
    }
}

[System.Serializable]
public class SpeedStats
{
    [SerializeField] private float baseSpeed = 5f;
    [SerializeField] private float speed = 5f;

    public float BaseSpeed
    {
        get => baseSpeed;
        set => baseSpeed = value;
    }

    public float Speed
    {
        get => speed;
        set => speed = Mathf.Clamp(value, 0, float.MaxValue);
    }
}

[System.Serializable]
public class DefenseStats
{
    [Header("Genel Savunma")]
    [SerializeField] private float defense = 0f;
    [SerializeField] private float defensePercent = 0f;

    [Header("Zırh (Armor)")]
    [SerializeField] private float armor = 0f;
    [SerializeField] private float armorPercent = 0f;

    [Header("Büyü Direnci (Magic Resist)")]
    [SerializeField] private float magicResist = 0f;
    [SerializeField] private float magicResistPercent = 0f;

    public float Defense
    {
        get => defense;
        set => defense = Mathf.Max(0, value);
    }

    public float DefensePercent
    {
        get => defensePercent;
        set => defensePercent = Mathf.Max(0, value);
    }

    public float Armor
    {
        get => armor;
        set => armor = Mathf.Max(0, value);
    }

    public float ArmorPercent
    {
        get => armorPercent;
        set => armorPercent = Mathf.Max(0, value);
    }


    public float MagicResist
    {
        get => magicResist;
        set => magicResist = Mathf.Max(0, value);
    }

    public float MagicResistPercent
    {
        get => magicResistPercent;
        set => magicResistPercent = Mathf.Max(0, value);
    }
    public float TotalArmor => armor + defense;
    public float TotalArmorPercent => ArmorPercent + defensePercent;

    public float TotalMagicResist => magicResist + defense;
    public float TotalMagicResistPercent => magicResistPercent + defensePercent;
}

[System.Serializable]
public class PenetrationStats
{
    [SerializeField] private float armorPenetration = 0f;
    [SerializeField] private float armorPenetrationPercent = 0f;
    [SerializeField] private float magicPenetration = 0f;
    [SerializeField] private float magicPenetrationPercent = 0f;
    public float ArmorPenetration
    {
        get => armorPenetration;
        set => armorPenetration = Mathf.Max(0, value);
    }
    public float ArmorPenetrationPercent
    {
        get => armorPenetrationPercent;
        set => armorPenetrationPercent = Mathf.Max(0, value);
    }
    public float MagicPenetration
    {
        get => magicPenetration;
        set => magicPenetration = Mathf.Max(0, value);
    }
    public float MagicPenetrationPercent
    {
        get => magicPenetrationPercent;
        set => magicPenetrationPercent = Mathf.Max(0, value);
    }
}

[System.Serializable]
public class CharacterStats
{
    public Character mycharacter;

    [Header("Health Settings")]
    public HealthStats healthStats;

    [Header("Mana Settings")]
    public ManaStats manaStats;

    [Header("Speed Settings")]
    public SpeedStats speedStats;

    [Header("Penetration Stats")]
    public PenetrationStats penetrationStats;

    [Header("Defense Settings")]
    public DefenseStats defenseStats;
}
