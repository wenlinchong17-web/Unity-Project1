using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
   

    public override void TakeDamage(int damage)
    {
        
        CurrentHP -= damage;
        Debug.Log("The Enemy is Damaged,Current HP: " + CurrentHP);
        if (CurrentHP <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        IsAlive = false;
        Debug.Log("The Enemy is Dead");
        Destroy(gameObject);
    }

    public void If_GetHit()
    {
        Debug.Log("Enemy GetHit");
    }
}
