using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorController : MonoBehaviour
{
    private Animator animator;

    public bool isDamaged;
    public bool falling;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        AnimatorHandler();
    }
    private void AnimatorHandler()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetTrigger("RunTrigger");
        }
        else
        {
            animator.SetTrigger("IdleTrigger");
        }

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("JumpTrigger");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("DoubleJumpTrigger");
        }
    }
}
