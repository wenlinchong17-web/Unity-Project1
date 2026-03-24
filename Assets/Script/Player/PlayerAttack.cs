using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator _animator;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
         AttackWithSword();
    }

    public void AttackWithSword()
    {
        if(Input.GetKeyDown(KeyCode.J)&&!player.IsAttacking)
            _animator.SetTrigger("Attack with sword");
    }

    
}
