using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    PlayerLife playerLife;
    public Transform RespawnPoint;
    SpriteRenderer spriteRenderer;
    public Sprite passive, active;
    private BoxCollider2D CheckPointCollider;

    private void Awake(){
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        CheckPointCollider=GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.CompareTag("Player")){
            playerLife.UpdateCheckpoint(RespawnPoint.position);
            spriteRenderer.sprite=active;
            CheckPointCollider.enabled=false;
        }
    }
}
