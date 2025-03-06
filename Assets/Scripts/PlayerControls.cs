using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private GatherInput input;

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    private bool facingRight = true;

    private void Update()
    {
        Flip();
    }

    private void FixedUpdate()
    {
        Move();
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
}
