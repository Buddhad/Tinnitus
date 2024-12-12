using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoMenu : MonoBehaviour
{
    [SerializeField]GameObject DemoDialogue;
    
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.name.Equals("Player")){
            ShowDemoDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if(col.gameObject.name.Equals("Player")){
            HideDemoDialogue();
        }
    }
    public void ShowDemoDialogue(){
    DemoDialogue.SetActive(true);
    }
    public void HideDemoDialogue(){
    DemoDialogue.SetActive(false);
    }
}
