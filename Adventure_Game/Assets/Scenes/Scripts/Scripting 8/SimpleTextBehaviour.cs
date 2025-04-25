using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleTextBehaviour : MonoBehaviour
{
    public TextMeshProUGUI experienceObj;
    //public TextMeshProUGUI scoreObj;
    public PlayerXP experienceData;
    //public PlayerScoreSO scoreData;

    private void Start()
    {
        //experienceObj.GetComponent<TextMeshProUGUI>();

        experienceObj.text = experienceData.currentXPLevel.ToString();
        //scoreObj.text = scoreData.currentScore.ToString();   
    }
    public void Update()
    {
        experienceObj.text = experienceData.currentXPLevel.ToString();
    }
    public void UpdateWithIntData()
    {
        //scoreObj.text = scoreData.currentScore.ToString();
    }
}
