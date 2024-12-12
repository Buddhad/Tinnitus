using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteDialogue : MonoBehaviour
{
    public GameObject WinPopupDialogue;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            WinPopupDialogue.SetActive(true);
            Time.timeScale=0;
        }
    }
}
