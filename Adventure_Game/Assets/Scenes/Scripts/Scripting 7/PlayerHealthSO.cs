using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Data", fileName = "PlayerHealth")]
public class PlayerHealthSO : ScriptableObject
{
    public float playerMaxHealth;
    private float currentPlayerHealth;

    public float healthPercantage;

    private void Awake()
    {
        currentPlayerHealth = playerMaxHealth;
    }

    public void PlayerTakeDamage(float damage)
    {
        if (currentPlayerHealth >= damage)
        {
            currentPlayerHealth -= damage;
        }
        else
        {
            currentPlayerHealth = 0;
        }

        healthPercantage = currentPlayerHealth / playerMaxHealth;
    }
    public void PlayerAddHealth(float health)
    {
        if (Mathf.Abs(currentPlayerHealth - playerMaxHealth) >= health)
        {
            currentPlayerHealth += health;
        }
        else
        {
            currentPlayerHealth = playerMaxHealth;
        }

        healthPercantage = currentPlayerHealth / playerMaxHealth;
    }
}
