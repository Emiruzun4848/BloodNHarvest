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
    public List<Attack> attacks = new List<Attack>();

    private void Awake()
    {
        myCharacter = GetComponent<Character>();
    }
}