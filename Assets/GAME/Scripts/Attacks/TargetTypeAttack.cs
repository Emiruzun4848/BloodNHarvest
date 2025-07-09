using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TargetTypeAttack : Attack
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 20f;

    protected override void DoThatAttack()
    {
       
    }
    public virtual void AttackCommand()
    {
       

        base.AttackCommand();
    }

    
}   