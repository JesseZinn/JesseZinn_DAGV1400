using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerScore")]
public class PlayerScoreSO : ScriptableObject
{
    public float currentScore;

    public void IncreaseScore(float value)
    {
        currentScore += value;
    }
}
