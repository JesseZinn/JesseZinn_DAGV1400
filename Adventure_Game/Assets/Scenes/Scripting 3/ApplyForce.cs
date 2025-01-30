using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * 500);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Character collided with " + collision.gameObject.name);
    }
}
