using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private LayerMask whatIsGround;
    private Rigidbody rb;
    public Transform orientation;

    public float moveSpeed;
    private float horizontalInput;
    public float jumpForce;

    public bool grounded;
    private bool readyToJump;

    public float groundDrag;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.drag = groundDrag;

        readyToJump = true;
    }
    private void Update()
    {
        MyInput();
        MovePlayer();
        SpeedControl();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) grounded = true;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) grounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) grounded = false;
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && grounded && readyToJump)
        {
            readyToJump = false;
            Jump();
        }
    }
    private void MovePlayer()
    {
        Vector3 moveDirection = orientation.right * horizontalInput;

        if (grounded)
        {
            rb.AddForce(moveDirection * moveSpeed * 10f, ForceMode.Force);
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
            rb.AddForce(moveDirection * moveSpeed * 10f, ForceMode.Force);

            if (rb.velocity.y < 0f)
            {
                rb.AddForce(-Vector3.up * 7f, ForceMode.Force);
            }
        }
    }
    private void SpeedControl()
    {
        Vector3 currentFlatVel = new Vector3(rb.velocity.x, 0, 0);
        if (currentFlatVel.magnitude > moveSpeed)
        {
            Vector3 limFlatVel = currentFlatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limFlatVel.x, rb.velocity.y, 0);
        }
    }
    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        Invoke("ResetJump", 0.05f);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}
