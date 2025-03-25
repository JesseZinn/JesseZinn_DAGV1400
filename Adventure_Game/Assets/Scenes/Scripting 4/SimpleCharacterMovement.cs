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
    public CharacterAnimatorController animController;
    private Vector3 velocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
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
            velocity.y = 0f;
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    private void CharacterMovement()
    {
        Vector3 move = new Vector3(moveInput, 0, 0) * (moveSpeed * Time.deltaTime);//I need to figure out why some animations are cntinung to run even after they shouldn't be
        //Has something to do from the Apply gravity function. For some reason I'm only grounded when I'm moving, otherwise I'm in the air
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
                //animController.falling = true;
            }
            else
            {
                animator.SetBool("FallBool", false);
            }
            //Debug.Log("air");
        }
        else
        {
            velocity.y = 0f;
            //animController.falling = false;
            //Debug.Log("grounded");
        }
        Debug.Log(velocity);
        controller.Move(velocity * Time.deltaTime);
    }

    private void KeepCharacterOnXAxis()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
