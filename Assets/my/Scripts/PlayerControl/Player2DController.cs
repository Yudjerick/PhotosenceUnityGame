using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Player2DController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public string mode = "3D";
    public Vector2 defaultPos;


    private bool isGrounded;
    private bool mustJump = false;
    private int triggeredObjects = 0;
    private bool hasKey = false;
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
        if(other.tag == "Key")
        {
            hasKey = true;
            Destroy(other.gameObject);
            return;
        }
        if (other.tag == "Door")
        {
            if (hasKey)
            {
                Debug.Log("Level passed");
                SceneManager.LoadScene(0);
            }
            return;
        }
        triggeredObjects++;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Key" || other.tag == "Door")
        {
            return;
        }
        
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
                transform.position = new Vector3(defaultPos.x, defaultPos.y, transform.position.z);
                rb.velocity = Vector2.zero;
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
            transform.position = new Vector3(defaultPos.x, defaultPos.y, transform.position.z);
            rb.velocity = Vector2.zero;
        }
    }

   
}
