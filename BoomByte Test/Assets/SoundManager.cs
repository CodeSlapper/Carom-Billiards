using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioSource mainMenuMusic;
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
        mainMenuMusic.volume = AudioListener.volume;
        SaveVolume();
    }

    private void LoadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("generalVolume");
        mainMenuMusic.volume = volumeSlider.value;
    }
    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("generalVolume", volumeSlider.value);

    }
}
