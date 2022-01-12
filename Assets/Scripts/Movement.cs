using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;

    //How fast we're moving
    public float moveSpeed;
    //To keep it simple this is how far we're dashing
    public float dashRange;

    //If this is false we're not dashing
    public bool dash;
    //Are we taking damage
    public bool HP = true;

    private Vector2 moveDirection;
    private Vector2 mousePos;

    // We Process Inputs here
    void Update()
    {
        ProcessInputs();
    }
    // We move and rotate player character here
    private void FixedUpdate()
    {
        Move();
        Rotate();
        Dash();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Vertical");
        float moveY = Input.GetAxisRaw("Horizontal");

        //Where are we moving
        moveDirection = new Vector2(moveY, moveX).normalized;

        //Where the mouse is
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //We dashin here
        dash = Input.GetKey(KeyCode.Space);
    }

    void Move()
    {
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    void Rotate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void Dash()
    {
        if (dash)
        {
            HP = false;
            rb.MovePosition(rb.position + moveDirection * dashRange * Time.deltaTime);
            StartCoroutine(iFrames());
        }
    }

    IEnumerator iFrames()
    {
        HP = false;
        yield return new WaitForSeconds(0.4f);
        HP = true;
    }
}
