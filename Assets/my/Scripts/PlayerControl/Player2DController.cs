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
    public GameObject winScreen;


    private bool isGrounded;
    private int mustJump = 0;
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
        if (mustJump > 0)
        {
            mustJump -= 1;
        }
        if (mode != "2D")
        {
            return;
        }
        rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
        if (mustJump > 0 && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            mustJump = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Key")
        {
            hasKey = true;
            Destroy(other.gameObject);
            return;
        }
        if (other.tag == "Deadly")
        {
            transform.position = new Vector3(defaultPos.x, defaultPos.y, transform.position.z);
            rb.velocity = Vector2.zero;
            return;
        }
        if (other.tag == "Door")
        {
            if (hasKey)
            {
                Debug.Log("Level passed");
                winScreen.SetActive(true);
                //SceneManager.LoadScene(0);
            }
            return;
        }
        triggeredObjects++;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Key" || other.tag == "Door" || other.tag == "Deadly")
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
            mustJump = 15;
        }
      
        if (Input.GetKeyDown(KeyCode.C))
        {
            mode = "3D";
            transform.position = new Vector3(defaultPos.x, defaultPos.y, transform.position.z);
            rb.velocity = Vector2.zero;
        }
    }

   
}
