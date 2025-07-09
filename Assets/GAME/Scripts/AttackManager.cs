using System.Collections.Generic;
using UnityEngine;
public enum AttackType
{
    CloseRange,
    Bullet,
    LongRange
}
public enum AttackPower
{
    Magic,
    Physical,
    Real
}
public class AttackManager : MonoBehaviour
{
    public BaseCharacter myCharacter;
    private bool canAttack = true;
    public List<Attack> allAttacks;
    public List<Attack> closeRangeAttack;

    public bool CanAttack
    {
        get => canAttack;
        set
        {
            canAttack = value;
            foreach (var attack in allAttacks)
            {
                attack.enabled = value;
            }
        }
    }
    private void Awake()
    {
        myCharacter = GetComponent<BaseCharacter>();
        allAttacks = new List<Attack>(GetComponents<Attack>());

    }
    private void Start()
    {
        closeRangeAttack = new List<Attack>();
        foreach (var attack in allAttacks)
        {
            if (attack.attackType == AttackType.CloseRange)
            {
                closeRangeAttack.Add(attack);
            }
        }
    }
}