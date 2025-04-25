    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleIDMatchBehaviour : MonoBehaviour
{
    public KeyID ID;
    public UnityEvent matchEvent, noMatchEvent;
    public GameObject fireWall;

    private void OnTriggerEnter(Collider other)
    {
        var otherID = other.GetComponent<SimpleIDBehaviour>();

        if (otherID == null)
        {
            return;
        }

        if (otherID.ID == ID)
        {
            matchEvent.Invoke();

            Destroy(fireWall);
            Destroy(otherID.gameObject);
            Debug.Log("Matched Id: " + ID);
        }
        else
        {
            noMatchEvent.Invoke();
            Debug.Log("No Match: " + ID);
        }
    }
}
