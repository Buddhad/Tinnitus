using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField]private Slider _musicSlider,_sfxSlider;
    //[SerializeField]private AudioMixer MyMixer;

    public void SetMusicVolume(){
        
    }
    public void ToggleMusic(){
        AudioManager.Instance.ToggleMusic();
    }
    public void ToggleSFX(){
        AudioManager.Instance.ToggleSFX();
    }
    public void MusicVolume(){
        AudioManager.Instance.MusicVolume(_musicSlider.value);
        

    }
    public void SFXVolume(){
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }
}
