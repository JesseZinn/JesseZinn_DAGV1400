using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorController : MonoBehaviour
{
    private Animator animator;
    public PlayerMovement pm;

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

        if (pm.rb.velocity.y > 0 && !pm.grounded)
        {
            animator.SetTrigger("JumpTrigger");
        }
        if (pm.rb.velocity.y < 0 && !pm.grounded)
        {
            animator.SetTrigger("FallTrigger");
        }
    }
}
