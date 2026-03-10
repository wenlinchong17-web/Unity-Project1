using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private Rigidbody2D _rb;
    private Vector2 _MoveInput;
    private SpriteRenderer _sprite;
    private GameObject WeaponPoint;
    private Animator _animator;
    private Transform _transform;

    public Transform HandBone;
    public List<GameObject> Weapons;
    public GameObject CurrentWeapon;
    public int CurrentWeaponIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        
        foreach(Transform child in HandBone)
        {
            Weapons.Add(child.gameObject);
            child.gameObject.SetActive(false);
            EquipWeapon(CurrentWeaponIndex);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        ChangeWeapon();
    }

    public void Move()
    {
        _MoveInput.x = Input.GetAxisRaw("Horizontal");
        _MoveInput.y = Input.GetAxisRaw("Vertical");
            
        AnimatorStateInfo _stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        IsAttacking = _stateInfo.IsName("Attack with sword");
        
        if (!IsAttacking&&IsGrounded)
        {
            if (_MoveInput.x > 0 && _transform.localScale.x < 0)
            {
                Debug.LogFormat("IsAttacking:{0}", IsAttacking);
                Flip();
            }
            else if (_MoveInput.x < 0 && _transform.localScale.x > 0)
            {
                Debug.LogFormat("IsAttacking:{0}", IsAttacking);
                Flip();
            }
        }

        if (!IsAttacking&&IsGrounded)
        {
            Debug.LogFormat("IsAttacking:{0}", IsAttacking);
            _rb.velocity = new Vector2(_MoveInput.x * MoveSpeed, _rb.velocity.y);
        }

        if (IsGrounded)
        {
            if (!IsAttacking)
            {
                _animator.SetFloat("Walk", Mathf.Abs(_MoveInput.x));
            }
            else 
            {
                _animator.SetFloat("Walk", 0);
            }
        }
        else
        {
            _animator.SetFloat("Walk", 0);
        }
        
        
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& IsGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, JumpSpeed);
        }

        if (!IsGrounded)
        {
            _MoveInput.x = Input.GetAxisRaw("Horizontal");
            _MoveInput.y = Input.GetAxisRaw("Vertical");
            if (_MoveInput.x > 0&&_transform.localScale.x<0)
            {
                Flip();
                _rb.velocity = new Vector2(Mathf.Abs(_rb.velocity.x), _rb.velocity.y);
            }
            else if (_MoveInput.x < 0&&_transform.localScale.x>0)
            {
                Flip();
                _rb.velocity = new Vector2(-Mathf.Abs(_rb.velocity.x), _rb.velocity.y);
            }
        }
    }

   

    public void EquipWeapon(int index)
    {
        if (index < 0 || index >= Weapons.Count)
        {
            Debug.Log("武器不存在!");
            return;
        }
            
        if (CurrentWeapon != null)
        {
            CurrentWeapon.SetActive(false);
        }
        CurrentWeapon =  Weapons[index];
        CurrentWeapon.SetActive(true);
        CurrentWeaponIndex =  index;
    }

    public void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            int index = (CurrentWeaponIndex+1)%Weapons.Count;
            EquipWeapon(index);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        throw new NotImplementedException();
        if (other.CompareTag("EnemyAttack"))
        {
            
        }
    }
}
