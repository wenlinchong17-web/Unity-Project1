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
    public bool IsGetHit;
    public bool IsAlive;
    
    [SerializeField] protected Collider2D[] weaponCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        DisableWeapon();
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
    
    public virtual void TakeDamage(int damage)
    {
        
        // CurrentHP -= damage;
        // Debug.Log("The character is Damaged,Current HP: " + CurrentHP);
        //
        // GetComponent<PlayerStats>()?.OnTakeDamage(damage);
        // if (CurrentHP <= 0)
        // {
        //     Die();
        // }
    }

    public virtual void Die()
    {
        // IsAlive = false;
        // Debug.Log("The character is Dead");
        // Destroy(gameObject);
    }
    
    //打开/关闭武器碰撞体积
    public void EnableWeapon()
    {
        foreach (var col in weaponCollider)
        {
            //Debug.Log("武器开启");
            col.enabled = true;
        }
    }

    public void DisableWeapon()
    {
        foreach (var col in weaponCollider)
        {
            //Debug.Log("武器关闭");
            col.enabled = false;
        }
    }
    
    //设置IsAttacking
    public void SetIsAttacking()
    {
        IsAttacking = true;
    }

    public void ResetIsA()
    {
        IsAttacking = false;
    }
}
