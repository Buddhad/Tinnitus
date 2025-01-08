using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Interactible : MonoBehaviour
{
    public bool IsInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    private void Update() {
        if(IsInRange){ //if we are in range then interact
            if(Input.GetKeyDown(interactKey)) //player press the key
            {
                interactAction.Invoke();//fire event
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            IsInRange=true;
            //Debug.Log("Player In Range");
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            IsInRange=false;
            //Debug.Log("Player is not In Range");
        }
    }

}
