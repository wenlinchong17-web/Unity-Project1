using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         AttackWithSword();
    }

    public void AttackWithSword()
    {
        AnimatorStateInfo _stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        if(Input.GetKeyDown(KeyCode.J)&&!_stateInfo.IsName("Attack with sword"))
            _animator.SetTrigger("Attack with sword");
    }
}
