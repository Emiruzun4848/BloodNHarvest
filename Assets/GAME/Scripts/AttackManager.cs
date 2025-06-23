using System.Collections.Generic;
using UnityEngine;
public enum AttackType
{
    CloseRange,
    LongRange
}
public enum AttackPower
{
    Magic,
    Physical
}
public class AttackManager : MonoBehaviour
{
    public Character myCharacter;
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
        myCharacter = GetComponent<Character>();
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