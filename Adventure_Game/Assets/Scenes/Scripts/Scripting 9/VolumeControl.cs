using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioSource musicSource;
    public Slider volumeSlider;

    private void Start()
    {
        volumeSlider.value = musicSource.volume;
        volumeSlider.onValueChanged.AddListener(delegate { AdjustVolume(); });
    }

    public void AdjustVolume()
    {
        musicSource.volume = volumeSlider.value;
    }
}
