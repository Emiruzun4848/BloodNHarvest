using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bulet Variables")]
    protected bool isEnabled = true;
    public float damage = 10f;
    public float speed = 10f;
    public float lifetime = 5f;


    [HideInInspector]
    public Attack fatherAttack;
    public Vector3 direction;
    protected BaseCharacter myCharacter;

    protected bool baseIsEnabled;
    protected float baseDamage,baseSpeed,baseLifetime;
    protected virtual void Awake()
    {
        Debug.Log("Bullet Awake Called");
        ResetVariable();
    }
    protected virtual void Start()
    {
        myCharacter = fatherAttack.attackManager.myCharacter;
        Debug.Log("Activated");
    }

    protected virtual void Update()
    {
        ControlConditions();
        if (baseIsEnabled)
        {
            UpdateBullet();
        }
    }
    protected virtual void UpdateBullet()
    {
        MoveBullet();
    }
    public virtual void ResetVariable()
    {
        baseIsEnabled = isEnabled;
        baseDamage = damage;
        baseSpeed = speed;
        baseLifetime = lifetime;
    }
    protected virtual void MoveBullet()
    {

    }

    protected virtual void ControlConditions()
    {
        
    }
    protected virtual void HitEnemy(Enemy enemy)
    {
        

    }

    protected virtual void SetDisabled()
    {
        baseIsEnabled = false;
        gameObject.SetActive(false);
    }
    public float GetDamage()
    {
        return damage;
    }
    protected void OnEnable()
    {
        ResetVariable();
    }
}