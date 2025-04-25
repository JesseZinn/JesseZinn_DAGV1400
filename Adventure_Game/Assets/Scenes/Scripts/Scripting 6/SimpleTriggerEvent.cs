using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleTriggerEvent : MonoBehaviour
{
    public UnityEvent triggerEvent, collisionEvent;
    public float hitForce;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            triggerEvent.Invoke();

            if (this.gameObject.CompareTag("Enemy"))
            {
                Vector3 direction = other.transform.position - transform.position;
                Vector3 flatDirection = new Vector3(direction.x, direction.y, 0);
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;
                other.GetComponent<Rigidbody>().AddForce(flatDirection.normalized * hitForce, ForceMode.Impulse);
                other.GetComponent<Rigidbody>().AddForce(Vector3.up * 4f, ForceMode.Impulse);
            }

            if (this.gameObject.CompareTag("Collectible"))
            {
                Destroy(gameObject);
            }
        }
    }
}
