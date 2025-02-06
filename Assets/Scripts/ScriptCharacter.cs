using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCharacter : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    [SerializeField] private Camera cam;

    private bool isGrounded = false;

    private float acceleration = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam.transform.position = new Vector3(transform.position.x, 5, cam.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
    }

    void MoveCharacter()
    {
        float horizontal = Input.GetAxis("Horizontal");
        // float vertical = Input.GetAxis("Vertical");

        if(cam.transform.position.x - transform.position.x >= 10)
        {
            cam.transform.position = new Vector3(transform.position.x + 10, cam.transform.position.y, cam.transform.position.z);
        }
        else if(cam.transform.position.x - transform.position.x <= -5)
        {
            cam.transform.position = new Vector3(transform.position.x - 5, cam.transform.position.y, cam.transform.position.z);
        }


        speed += horizontal;
        if (speed < -10)
        {
            speed = -10;
        }
        else if (speed > 10)
        {
            speed = 10;
        }
        else if(horizontal == 0)
        {
            speed /= 5;
        }
        Vector2 movement = new Vector2(speed, rb.velocity.y);
        rb.velocity = movement;
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}