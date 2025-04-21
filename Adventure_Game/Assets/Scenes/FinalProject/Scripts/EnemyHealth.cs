using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;

    private bool dead;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            IsDead();
        }
    }
    public void TakeDamage(int damage)
    {
        Debug.Log("hit");
        currentHealth -= damage;
    }
    private void IsDead()
    {
        Destroy(gameObject);
    }
}
