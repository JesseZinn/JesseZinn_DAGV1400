using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SimpleImageBehaviour : MonoBehaviour
{
    public PlayerHealthSO dataObj;
    public Image imageObj;

    private void Start()
    {
        imageObj = GetComponent<Image>();
    }
    public void UpdateWithFloatData()
    {
        imageObj.fillAmount = dataObj.healthPercantage;
    }
}
