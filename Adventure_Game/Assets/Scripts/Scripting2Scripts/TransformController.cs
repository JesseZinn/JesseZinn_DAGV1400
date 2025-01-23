using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformController : MonoBehaviour
{
    public GameObject targetTransform;

    void Update()
    {
        float x = Mathf.PingPong(Time.time, 3);
        Vector3 p = new Vector3(0, x, 0);

        transform.position = p;

        targetTransform.transform.Rotate(new Vector3(50, 30, 10) * Time.deltaTime);
    }
}
