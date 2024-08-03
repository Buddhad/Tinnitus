using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Damage : MonoBehaviour
{
    public PlayerMovement playerMovement;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Player"){
            playerMovement.KBCounter=playerMovement.KBTotalTime;
            if(other.transform.position.x<=transform.position.x){
                playerMovement.KnockBackFormRight=true;
            }
            if(other.transform.position.x > transform.position.x){
                playerMovement.KnockBackFormRight=false;
            }
        }
    }
}
