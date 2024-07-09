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
    //[SerializeField] private AudioSource CheckPointSound;

    private void Awake(){
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        CheckPointCollider=GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            //CheckPointSound.Play();
            AudioManager.Instance.PlaySFX("Checkpoint");
            playerLife.UpdateCheckpoint(RespawnPoint.position);
            spriteRenderer.sprite=active;
            CheckPointCollider.enabled=false;
        }
    }
}
