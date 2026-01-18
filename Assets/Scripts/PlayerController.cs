using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 3f;

    [SerializeField] TextController textScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector2 moveInput;
    Rigidbody2D _rb;
    Animator _anim;

    bool isGrounded = true;
    bool isAlive = true;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded)
        {
            _rb.linearVelocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, _rb.linearVelocity.y);
        _rb.linearVelocity = playerVelocity;
        bool hasHorizontalSpeed = Mathf.Abs(_rb.linearVelocity.x) > Mathf.Epsilon;
        _anim.SetBool("IsRunning", hasHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool hasHorizontalSpeed = Mathf.Abs(_rb.linearVelocity.x) > Mathf.Epsilon;
        if (hasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(_rb.linearVelocity.x), 1f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cave"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Enemy") && isAlive)
        {
            isAlive = false;

            if (textScript != null)
            {
                textScript.ToogleText();
            }

            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cave"))
        {
            isGrounded = false;
        }
    }


}