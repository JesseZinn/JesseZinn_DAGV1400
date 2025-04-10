using UnityEngine;

public class AttachOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent = other.transform;
        }
    }
}
