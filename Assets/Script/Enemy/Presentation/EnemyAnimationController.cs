using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private static readonly int SpeedHash = Animator.StringToHash("Speed");
    private static readonly int AttackHash = Animator.StringToHash("Attack");
    private static readonly int DeathHash = Animator.StringToHash("Death");

    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void SetMoveSpeed(float speed)
    {
        animator.SetFloat(SpeedHash, speed);
    }

    public void PlayAttack()
    {
        animator.SetTrigger(AttackHash);
    }

    public void PlayDeath()
    {
        animator.SetTrigger(DeathHash);
    }
}