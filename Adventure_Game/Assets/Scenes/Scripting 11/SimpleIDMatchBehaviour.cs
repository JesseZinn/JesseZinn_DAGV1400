using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleIDMatchBehaviour : MonoBehaviour
{
    public UnityEvent matchEvent, noMatchEvent;

    public KeyID ID;

    private void OnTriggerEnter(Collider other)
    {
        var otherID = other.GetComponent<SimpleIDBehaviour>();

        if (otherID.ID == ID)
        {
            matchEvent.Invoke();
            Debug.Log("Matched Id: " + ID);
        }
        else
        {
            noMatchEvent.Invoke();
            Debug.Log("No Match: " + ID);
        }
    }
}
