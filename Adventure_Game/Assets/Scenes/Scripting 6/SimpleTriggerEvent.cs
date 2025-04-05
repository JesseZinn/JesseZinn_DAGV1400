using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleTriggerEvent : MonoBehaviour
{
    public UnityEvent triggerEvent, collisionEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            triggerEvent.Invoke();

            if (this.gameObject.CompareTag("Collectible"))
            {
                //Destroy(this.gameObject);
                //this.gameObject.isStatic;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collisionEvent.Invoke();
            Debug.Log("FIRE");
        }
    }
}
