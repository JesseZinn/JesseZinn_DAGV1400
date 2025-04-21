using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipTransformBehavior : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public KeyCode key1 = KeyCode.D, key2 = KeyCode.A;
    public float direction1 = 0f, direction2 = 180f;

    public bool right, left;

    private void Update()
    {
        if (Input.GetKey(key1) && !Input.GetKey(key2))
        {
            transform.rotation = Quaternion.Euler(0, direction1, 0);
            right = true;
            left = false;
        }
        if (Input.GetKey(key2) && !Input.GetKey(key1))
        {
            transform.rotation = Quaternion.Euler(0, direction2, 0);
            left = true;
            right = false;
        }
    }
}
