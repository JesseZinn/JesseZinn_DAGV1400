using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterMovement : MonoBehaviour
{
    public float moveSpeed;
    private CharacterController controller;
    private Vector3 movementVector;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        CharacterMovement();
        KeepCharacterOnXAxis();
    }

    private void CharacterMovement()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector *= moveSpeed * Time.deltaTime;
        controller.Move(movementVector);
    }

    private void KeepCharacterOnXAxis()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
