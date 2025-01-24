using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformController : MonoBehaviour
{
    public Transform targetTransform;

    void Update()
    {
        float speed = 5;
        float x = Mathf.PingPong(Time.time * speed, 5);
        Vector3 p = new Vector3(0, x, x);

        transform.position = p;

        targetTransform.transform.Rotate(new Vector3(30, 20, 50) * Time.deltaTime);
        targetTransform.localScale = new Vector3(x + 1, 1, 1);
    }
}
