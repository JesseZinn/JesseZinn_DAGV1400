using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterMovement : MonoBehaviour
{
    private float moveInput;
    public float moveSpeed;
    public float jumpForce;
    public float gravity = -9.81f;

    private CharacterController controller;
    public Animator animator;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        MyInput();
        CharacterMovement();
        ApplyGravity();
        KeepCharacterOnXAxis();
    }

    private void MyInput()
    {
        moveInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    private void CharacterMovement()
    {
        Vector3 move = new Vector3(moveInput, 0, 0) * (moveSpeed * Time.deltaTime);
        controller.Move(move);
    }

    private void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;

            if (velocity.y < 0)
            {
                animator.SetBool("FallBool", true);
            }
        }
        else
        {
            velocity.y = 0f;
        }

        controller.Move(velocity * Time.deltaTime);
    }

    private void KeepCharacterOnXAxis()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
