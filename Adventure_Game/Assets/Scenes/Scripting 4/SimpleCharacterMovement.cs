using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float gravity = -9.81f;

    public bool grounded;

    private CharacterController controller;
    public Animator animator;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        CharacterMovement();
        ApplyGravity();
        KeepCharacterOnXAxis();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }

    private void CharacterMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(moveInput, 0, 0) * (moveSpeed * Time.deltaTime);
        controller.Move(move);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    private void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        if (!grounded)
        {
            velocity.y += gravity * Time.deltaTime;

            if (velocity.y < 0)
            {
                animator.SetTrigger("FallTrigger");
            }
            Debug.Log("In the air");
        }
        else
        {
            velocity.y = 0f;
            Debug.Log("goruded");
        }

        controller.Move(velocity * Time.deltaTime);
    }

    private void KeepCharacterOnXAxis()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
