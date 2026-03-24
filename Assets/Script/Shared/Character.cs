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
    
    //受击逻辑
    public virtual void TakeDamage(int damage) {}
    //死亡逻辑
    public virtual void Die() {}
    
    //打开/关闭武器碰撞体积
    public void EnableWeapon()
    {
        foreach (var col in weaponCollider)
        {
            col.enabled = true;
        }
    }

    public void DisableWeapon()
    {
        foreach (var col in weaponCollider)
        {
            col.enabled = false;
        }
    }
    
    //设置IsAttacking（动画Envent）
    public void SetIsAttacking()
    {
        IsAttacking = true;
    }

    public void ResetIsAttaking()
    {
        IsAttacking = false;
    }
    
    //设置IsGetHit
    public void SetIsGetHit()
    {
        IsGetHit = true;
    }
    public void ResetIsGetHit()
    {
        IsGetHit = false;
    }
}
