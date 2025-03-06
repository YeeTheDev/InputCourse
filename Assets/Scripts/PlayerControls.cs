using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private GatherInput input;

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = new Vector2(speed * input.valueX, rb.velocity.y);
    }
}
