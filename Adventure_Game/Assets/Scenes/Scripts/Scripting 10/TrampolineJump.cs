using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineJump : MonoBehaviour
{
    public float jumpForce;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("rigid");
        }
        else
        {
            Vector3 objVelocity = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
            objVelocity.y = Mathf.Sqrt(jumpForce * -2f * -9.81f);
            Debug.Log("dumb");
        }
    }
}
