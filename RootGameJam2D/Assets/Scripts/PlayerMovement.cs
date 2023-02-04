using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private  float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Camera cam;
    Vector2 mousePos;
    bool facingRight = true;
   

    
    void Start()
    {
    rb=GetComponent<Rigidbody2D>();     
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos=cam.ScreenToWorldPoint(Input.mousePosition);
        if(mousePos.x<transform.position.x && facingRight)
        {
            flip();
        }
        else if(mousePos.x > transform.position.x && !facingRight)
        {
            flip();
        }
        
    }
    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180f, 0);

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDirection=mousePos-rb.position;
        float angle = Mathf.Atan2(lookDirection.y,lookDirection.x)*Mathf.Rad2Deg-90f;
        rb.rotation = angle;
    }
}
