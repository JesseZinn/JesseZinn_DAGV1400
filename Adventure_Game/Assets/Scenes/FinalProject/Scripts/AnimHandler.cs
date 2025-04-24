using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimHandler : MonoBehaviour
{
    public Animator anim;

    public bool running, idle, hit;

    private void Start()
    {
        running = false;
        idle = true;
        hit = false;
    }
    private void Update()
    {
        if (running)
        {
            hit = false;
            idle = false;
            anim.SetTrigger("RunTrigger");
            running = false;
        }
        else if (hit)
        {
            running = false;
            idle = false;
            anim.SetTrigger("HitTrigger");
            hit = false;
        }
        else if (idle)
        {
            running = false;
            hit = false;
            anim.SetTrigger("IdleTrigger");
            idle = false;
        }
    }
}
