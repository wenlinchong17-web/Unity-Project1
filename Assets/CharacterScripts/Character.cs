using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int MaxHP;
    public int CurrentHP;
    public int MaxMP;
    public int CurrentMP;

    public float MoveSpeed = 5f;
    public float JumpSpeed = 10f;
    public bool IsGrounded = true;
    public bool Direction = true;//true表示向右，false表示向左
    
    private Rigidbody2D _rb;
    private Vector2 _MoveInput;
    private SpriteRenderer _sprite;
    private GameObject WeaponPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        Transform wp = transform.Find("WeaponPoint");
        if (wp != null)
        {
            WeaponPoint = wp.gameObject;
        }
        else
        {
            Debug.LogError("WeaponPoint Not Found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    public void Move()
    {
        if (IsGrounded)
        {
            _MoveInput.x = Input.GetAxisRaw("Horizontal");
            _MoveInput.y = Input.GetAxisRaw("Vertical");
            if (_MoveInput.x > 0)
            {
                _sprite.flipX = false;
                WeaponPoint.transform.localPosition = new Vector3(1f,0.5f,0.5f);
                WeaponPoint.transform.localRotation = Quaternion.Euler(0, 0, -34.938f);
            }
            else if (_MoveInput.x < 0)
            {
                _sprite.flipX = true;
                WeaponPoint.transform.localPosition = new Vector3(-0.5f,0.3f,0.5f);
                WeaponPoint.transform.localRotation = Quaternion.Euler(0, 0, 55.657f);
            }
            _rb.velocity = new Vector2(_MoveInput.x * MoveSpeed, _rb.velocity.y);
            
        }
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
            if (_MoveInput.x > 0)
            {
                _sprite.flipX = false;
                WeaponPoint.transform.localPosition = new Vector3(1f,0.5f,0.5f);
                WeaponPoint.transform.localRotation = Quaternion.Euler(0, 0, -34.938f);
                _rb.velocity = new Vector2(Mathf.Abs(_rb.velocity.x), _rb.velocity.y);
            }
            else if (_MoveInput.x < 0)
            {
                _sprite.flipX = true;
                WeaponPoint.transform.localPosition = new Vector3(-0.5f,0.3f,0.5f);
                WeaponPoint.transform.localRotation = Quaternion.Euler(0, 0, 55.657f);
                _rb.velocity = new Vector2(-Mathf.Abs(_rb.velocity.x), _rb.velocity.y);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }
}
