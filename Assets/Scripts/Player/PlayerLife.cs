using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{    
    Vector2 CheckPointPos;
    SpriteRenderer sr;
    [SerializeField] private AudioSource DieSound;

    private void Awake() {
    sr=GetComponent<SpriteRenderer>();
    
}
    private void Start() {
        CheckPointPos=transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Trap")){
            Die();
        }
    }

    void Die(){
        DieSound.Play();
        StartCoroutine(Respawn(0.3f));
    }

    public void UpdateCheckpoint(Vector2 pos){
        CheckPointPos=pos;
    }
    IEnumerator Respawn(float duration){
        sr.enabled=false;
        yield return new WaitForSeconds(duration);
        transform.position=CheckPointPos;
        sr.enabled=true;
    }
    
}
