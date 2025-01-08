using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyHolder : MonoBehaviour
{
    public int keyCount;
    public TextMeshProUGUI KeyText;


    public void PickupKey(){
        keyCount++;
        KeyText.text=""+keyCount;
        AudioManager.Instance.PlaySFX("Key");
        //Debug.Log("Get a key");
    }

    public void UseKey(){
        keyCount--;
        KeyText.text=""+keyCount;
        AudioManager.Instance.PlaySFX("Key");
        //Debug.Log("Key is used to open now no key left");
    }

}
