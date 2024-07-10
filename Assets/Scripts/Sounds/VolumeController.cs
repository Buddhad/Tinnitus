using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField]private AudioMixer audioMixer;
    [SerializeField]private Slider musicSlider;
    [SerializeField]private Slider sfxSlider;

private void Start() {
    if(PlayerPrefs.HasKey("musicVolume")){
    LoadVolume();
    }else{
        SetMusicVolume();
        SetSFXVolume();
    }
    
}
    public void SetMusicVolume(){
        float volume=musicSlider.value;
        audioMixer.SetFloat("music",Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume",volume);
    }

    public void SetSFXVolume(){
        float volume=sfxSlider.value;
        audioMixer.SetFloat("SFX",Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SFXVolume",volume);
    }

    public void LoadVolume(){
        musicSlider.value=PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value=PlayerPrefs.GetFloat("SFXVolume");
        SetMusicVolume();
        SetSFXVolume();
    }
}
