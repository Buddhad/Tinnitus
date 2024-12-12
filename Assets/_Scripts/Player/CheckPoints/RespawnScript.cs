using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject RespawnPoint;
    [SerializeField] private AudioSource DeathLineSound;

    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            DeathLineSound.Play();
            Player.transform.position=RespawnPoint.transform.position;
        }
    }
}
