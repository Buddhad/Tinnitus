using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    Vector2 startPos;
    SpriteRenderer sr;

    private void Awake() {
    sr=GetComponent<SpriteRenderer>();
}
    private void Start() {
        startPos=transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Trap")){
            Die();
        }
    }

    void Die(){
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration){
        sr.enabled=false;
        yield return new WaitForSeconds(duration);
        transform.position=startPos;
        sr.enabled=true;
    }
    
}
