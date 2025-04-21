using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomBullet : MonoBehaviour
{
    public float bulletDuration;
    public int damage;

    private void Update()
    {
        bulletDuration -= Time.deltaTime;
        if (bulletDuration <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            other.GetComponent<AnimHandler>().idle = false;
            other.GetComponent<AnimHandler>().running = false;
            other.GetComponent<AnimHandler>().hit = true;
            Destroy(gameObject);
        }
    }
}
