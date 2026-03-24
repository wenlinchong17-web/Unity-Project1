using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    [SerializeField] private Collider2D[] weaponCllider;
    private Animator animator ;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        DisableWeapon();
        IsGetHit = false;
        CurrentHP = MaxHP;
        CurrentMP = MaxMP;
    }

    // Update is called once per frame
    void Update()
    {
        //IsGetHit = animator.GetCurrentAnimatorStateInfo(0).IsName("Get Hit");
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("PlayerAttack"))
        {
            if (!IsGetHit)
            {
                animator.SetTrigger("GetHit");
                Damage playerDamage = other.GetComponent<Damage>();
                int damage = playerDamage.damage;
                TakeDamage(damage);
            }
            
        }
    }
    
}
