using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3DController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float jumpForce;
    public string mode = "3D";
    private bool isGrounded = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(mode != "3D")
        {
            return;
        }

        rb.velocity = new Vector3(speed * Input.GetAxisRaw("Horizontal"), rb.velocity.y, speed * Input.GetAxisRaw("Vertical"));
    }

    private void Update()
    {
        if (mode != "3D")
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                mode = "3D";
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            mode = "2D";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }
}
