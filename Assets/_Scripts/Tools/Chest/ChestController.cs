using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChestController : MonoBehaviour
{
    public int ChestCount=0;
    public TextMeshProUGUI ChestText;
    public bool isOpen;
    public Animator anim;
    public TextMeshProUGUI HighChestText;
    public void OpenChest(){
        if(!isOpen){
            isOpen=true;
            anim.SetBool("IsOpen",isOpen);
            ChestCount++;
            ChestText.text=""+ChestCount;
            AudioManager.Instance.PlaySFX("Chest");
            //Debug.Log("Chest is open now");
            showHightScore();
        }
    }
    void showHightScore(){
        HighChestText.text="Chest: "+ChestCount;
    }
}
