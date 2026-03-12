using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int MaxHP;
    public int CurrentHP;
    public int MaxMP;
    public int CurrentMP;

    public float MoveSpeed;
    public float JumpSpeed;
    public bool IsGrounded;
    public bool IsAttacking;
    public bool IsAlive;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //检测地面碰撞
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }

    protected void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }
    
    public void TakeDamage(int damage)
    {
        CurrentHP -= damage;
        if (CurrentHP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        IsAlive = false;
        Debug.Log("The character is Dead");
    }
}
