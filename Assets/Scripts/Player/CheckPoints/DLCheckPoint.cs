using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLCheckPoint : MonoBehaviour
{
    private RespawnScript respawn;
    private BoxCollider2D CheckPointCollider;


    void Awake() {
        CheckPointCollider=GetComponent<BoxCollider2D>();
        respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnScript>();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            respawn.RespawnPoint=this.gameObject;
            CheckPointCollider.enabled=false;
        }
    }
}
