using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private GatherInput input;

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    [Header("Jump")]
    [SerializeField] float jumpForce;

    [Header("Ground Check")]
    [SerializeField] private float rayLength;
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;
    [SerializeField] private LayerMask detectLayer;

    private bool grounded;
    private bool facingRight = true;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Flip();
        SetAnimationValues();
    }

    private void FixedUpdate()
    {
        GroundCheck();
        Move();
        Jump();
    }

    private void Move()
    {
        rb.velocity = new Vector2(speed * input.valueX, rb.velocity.y);
    }

    private void Flip()
    {
        if (facingRight && input.valueX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            facingRight = !facingRight;
        }
        else if (!facingRight && input.valueX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            facingRight = !facingRight;
        }
    }

    private void Jump()
    {
        if (input.tryToJump)
        {
            if (grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }

            input.tryToJump = false;
        }
    }

    private void GroundCheck()
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(leftPoint.position, Vector2.down, rayLength, detectLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(rightPoint.position, Vector2.down, rayLength, detectLayer);
        if (hitLeft || hitRight)
            grounded = true;
        else
            grounded = false;
    }

    private void SetAnimationValues()
    {
        animator.SetFloat("SpeedX", Mathf.Abs(rb.velocity.x));
    }
}
