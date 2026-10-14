using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class topdowncontroller : MonoBehaviour
{

    public Rigidbody2D rb;

    [SerializeField] float moveSpeed = 5.0f;

    float moveX;

    [SerializeField] float jumpForce;

    float fireVelocityX;
    [SerializeField] float fireVelocityDecay = 12f;

    bool isGround = false;

    public float xPos;
    public float yPos;

    [SerializeField] CursorController cursor;

    bool isLeft;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.linearVelocityX = moveX * moveSpeed + fireVelocityX;
        fireVelocityX = Mathf.MoveTowards(fireVelocityX, 0f, fireVelocityDecay * Time.fixedDeltaTime);

        xPos = transform.position.x;
        yPos = transform.position.y;
        
        isLeft = cursor.isLeft;
    }

    void OnMove(InputValue value)
    {
        moveX = value.Get<Vector2>().x;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }

    void OnJump()
    {
        if(isGround)
        {
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnFire()
    {
        if(!isGround && Math.Abs(fireVelocityX) <= (jumpForce * 0.25))
        {
            float jet;
            if(!isLeft)
            {
                jet = -1.5f * jumpForce;
            }
            else
            {
                jet = jumpForce;
            }
            fireVelocityX += jet;
        }
    }
}
