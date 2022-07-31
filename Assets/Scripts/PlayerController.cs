using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public bool jumpInput;

    [Header("Settings")]
    public float playerSize = 2f;
    public float jumpForce = 20f;
    public float maxVelocity = 5f;
    public LayerMask groundCollision;
    [Header("State")]
    public bool IsGrounded;
    public bool IsRun;
    public bool IsFaceRight;

    [Header("Collision")]
    public Transform luCorner;
    public Transform brCorner;

    private Animator animator;
    private Rigidbody2D rb2d;
    private float movementOfPlayer;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider;

    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Mathf.Abs(movementOfPlayer) > 0)
        {
            IsRun = true;
        }
        else
        {
            IsRun = false;
        }
        animator.SetBool("IsRun", IsRun);

        animator.SetBool("IsGrounded", IsGrounded);

        animator.SetFloat("JumpAndFall", rb2d.velocity.normalized.y);

        if (movementOfPlayer > 0 && !IsFaceRight)
        {
            Flip();
        }
        else if (movementOfPlayer < 0 && IsFaceRight)
        {
            Flip();
        }

    }
    void FixedUpdate()
    {
        movementOfPlayer = horizontalInput * maxVelocity;

        rb2d.velocity = new Vector2(movementOfPlayer, rb2d.velocity.y);

        if (jumpInput && IsGrounded)
        {
            rb2d.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        IsGrounded = Physics2D.OverlapArea(luCorner.position, brCorner.position, groundCollision); ;

    }
    private void Flip()
    {
        IsFaceRight = !IsFaceRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
