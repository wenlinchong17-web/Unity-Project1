using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public int damage = 10;
    
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    public void Attack()
    {
        AnimatorStateInfo _stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        if(Input.GetKeyDown(KeyCode.J)&&!_stateInfo.IsName("Attack with Sword"))
            _animator.SetTrigger("Attack with Sword");
    }
}
