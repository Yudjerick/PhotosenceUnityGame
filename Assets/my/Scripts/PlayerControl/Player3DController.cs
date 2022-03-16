using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3DController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float jumpForce;
    //public string mode = "2D";
    private bool isGrounded = true;
    private int triggeredObjects = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Mode.mode != "3D")
        {
            return;
        }

        rb.velocity = new Vector3(speed * Input.GetAxisRaw("Horizontal"), rb.velocity.y, speed * Input.GetAxisRaw("Vertical"));
    }

    private void Update()
    {
        isGrounded = true;
        if (triggeredObjects == 0)
        {
            isGrounded = false;
        }

        if (Mode.mode != "3D")
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        triggeredObjects += 1;
    }
    private void OnTriggerExit(Collider other)
    {
        triggeredObjects -= 1; ;
    }
}
