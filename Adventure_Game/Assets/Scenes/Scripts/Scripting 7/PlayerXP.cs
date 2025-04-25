using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "PlayerXP")]
public class PlayerXP : ScriptableObject
{
    public int currentXPLevel;
    public float maxXP;
    public float currentXP;
    public float experiencePercantage;

    private void Awake()
    {
        currentXPLevel = 0;
        currentXP = 0;
    }
    public void PlayerGainXP(float value)
    {
        if (Mathf.Abs(currentXP - maxXP) > value)
        {
            currentXP += value;
        }
        else
        {
            currentXP = Mathf.Abs(value - Mathf.Abs(currentXP - maxXP));
            currentXPLevel += 1;
        }

        experiencePercantage = currentXP / maxXP;
    }

    public void PlayerLoseXP(float value)
    {
        if (currentXP < value)
        {
            currentXP = 0;
        }
        else
        {
            currentXP -= value;
        }

        experiencePercantage = currentXP / maxXP;
    }
}
