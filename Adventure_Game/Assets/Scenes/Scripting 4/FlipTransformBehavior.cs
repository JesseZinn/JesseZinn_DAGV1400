using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipTransformBehavior : MonoBehaviour
{
    public KeyCode key1 = KeyCode.D, key2 = KeyCode.A;
    public float direction1 = 0f, direction2 = 180f;

    private void Update()
    {
        if (Input.GetKeyDown(key1))
        {
            transform.rotation = Quaternion.Euler(0, direction1, 0);
        }
        if (Input.GetKeyDown(key2))
        {
            transform.rotation = Quaternion.Euler(0, direction2, 0);
        }
    }
}
