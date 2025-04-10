using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SimpleImageBehaviour : MonoBehaviour
{
    public PlayerHealthSO healthObj;
    public PlayerXP experienceObj;
    public Image imageObj;

    private void Start()
    {
        imageObj = GetComponent<Image>();
    }
    public void UpdateWithHealthData()
    {
        imageObj.fillAmount = healthObj.healthPercantage;
    }
    public void UpdateWithXPData()
    {
        imageObj.fillAmount = experienceObj.experiencePercantage;
    }
}
