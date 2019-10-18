using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rb;
    public bool grounded;
    private Collider2D myCollider;

    public LayerMask WhatIsGround;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        grounded = Physics2D.IsTouchingLayers(myCollider, WhatIsGround);

        rb.velocity = new Vector3(moveSpeed * Time.deltaTime, rb.velocity.y);


        if (grounded && (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
        }

    }
}
