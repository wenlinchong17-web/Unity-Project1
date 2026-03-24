using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    public float PatrolSpeed = 2f;
    public float ChaseSpeed = 3f;
    public float DetectRange = 5f;
    public float AttackRange = 3f;
    private float lastAttackTime;
    public float AttackCoolDown = 2f;
    //巡逻点位
    public Transform PointA; 
    public Transform PointB;
    
    private Rigidbody2D rb;
    [SerializeField]
    private Animator animator;
    
    [SerializeField]
    private EnemyState currentState;
    [SerializeField]
    private Transform targetPoint;

    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        currentState = EnemyState.Patrol;
        targetPoint = PointB;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(Player.position, transform.position);

        switch (currentState)
        { 
            case EnemyState.Patrol: 
                Patrol();
                if (distanceToPlayer <= DetectRange)
                {
                    currentState = EnemyState.Chase;
                }
                break;
            
            case EnemyState.Chase:
                Chase();
                if (distanceToPlayer <= AttackRange)
                {
                    currentState = EnemyState.Attack;
                }
                else if (distanceToPlayer > DetectRange)
                {
                    currentState = EnemyState.Patrol;
                }
                break;
            
            case EnemyState.Attack:
                Attack();
                if (distanceToPlayer > AttackRange)
                {
                    currentState = EnemyState.Chase;
                }
                break;
        }
    }
    
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
        
    public void Patrol()
    {
        animator.SetFloat("Walk", 1f);
        Debug.Log("Patrol is running");
        float dir = targetPoint.position.x - transform.position.x;

        // 移动
        rb.velocity = new Vector2(Mathf.Sign(dir) * PatrolSpeed, rb.velocity.y);

        //实时修正朝向
        if (dir > 0 && transform.localScale.x < 0)
            Flip();
        else if (dir < 0 && transform.localScale.x > 0)
            Flip();

        // 到达判断
        if (Mathf.Abs(dir) < 0.5f)
        {
            targetPoint = targetPoint == PointA ? PointB : PointA;
        }
    }
    
    public void Chase()
    {
        animator.SetFloat("Walk", 1f);

        Vector2 dir = (Player.position - transform.position).normalized;
        rb.velocity = new Vector2(dir.x * ChaseSpeed, rb.velocity.y);

        // 朝向玩家
        if (dir.x > 0 && transform.localScale.x < 0)
            Flip();
        else if (dir.x < 0 && transform.localScale.x > 0)
            Flip();
    }

    public void Attack()
    {
        if (Time.time - lastAttackTime >= AttackCoolDown)
        {
            animator.SetTrigger("Attack");
            lastAttackTime =  Time.time;
        }
        
    }
    
    
}
