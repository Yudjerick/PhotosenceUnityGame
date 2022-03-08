using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public string mode = "3D";
    private bool isGrounded;
    private bool mustJump = false;
    private int triggeredObjects = 0;
    void Start()
    {
        isGrounded = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(mode != "2D")
        {
            return;
        }
        rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        triggeredObjects++;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        triggeredObjects--;
    }

    private void Update()
    {
        isGrounded = true;
        if(triggeredObjects == 0)
        {
            isGrounded = false;
        }

        if (mode != "2D")
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                mode = "2D";
            }
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mustJump = true;
        }
        if (mustJump && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            mustJump = false;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            mode = "3D";
        }
    }

   
}
