using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    void Start()
    {
        if(!PlayerPrefs.HasKey("generalVolume"))
        {
            PlayerPrefs.SetFloat("generalVolume", 1);
            LoadVolume();
        }
        else
        {
            LoadVolume();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        SaveVolume();
    }

    private void LoadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("generalVolume");
    }
    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("generalVolume", volumeSlider.value);
    }
}
