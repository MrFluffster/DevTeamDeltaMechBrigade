using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;

    public float moveSpeed;

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
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Vertical");
        float moveY = Input.GetAxisRaw("Horizontal");

        moveDirection = new Vector2(moveY, moveX).normalized;

        //Where the mouse is
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
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
}
