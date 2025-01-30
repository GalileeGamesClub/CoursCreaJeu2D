using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCharacter : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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



        
        Vector2 movement = new Vector2(horizontal*speed, rb.velocity.y);
        rb.velocity = movement;
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
        }
    }
}
