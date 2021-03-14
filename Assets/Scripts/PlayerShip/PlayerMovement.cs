using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;


        //Acceleration example, Level 2

    //this is our target velocity while decelerating
    float initialVelocity = 0f;

    //this is our target velocity while accelerating
    float finalVelocity = 500f;

    //this is our current velocity
    float currentVelocity = 0f;

    //this is the velocity we add each second while accelerating
    float accelerationRate = 10f;

    //this is the velocity we subtract each second while decelerating
    float decelerationRate = 50f;

    /*void Update ()
    {

        if(Input.GetAxis("Vertical") > 0)
        {
            //add to the current velocity according while accelerating
            currentVelocity = currentVelocity + (accelerationRate * Time.deltaTime);
        }
        else
        {
            //subtract from the current velocity while decelerating
            currentVelocity = currentVelocity - (decelerationRate * Time.deltaTime);
        }

        //ensure the velocity never goes out of the initial/final boundaries
        currentVelocity = Mathf.Clamp(currentVelocity, initialVelocity, finalVelocity);
        print(currentVelocity);

    }*/

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
