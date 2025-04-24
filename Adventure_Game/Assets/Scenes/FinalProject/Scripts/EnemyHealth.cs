using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    public AnimHandler enemyAnim;

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
        currentHealth -= damage;
        enemyAnim.running = false;
        enemyAnim.idle = false;
        enemyAnim.hit = true;
    }
    private void IsDead()
    {
        Destroy(gameObject);
    }
}
