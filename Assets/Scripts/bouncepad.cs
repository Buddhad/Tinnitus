using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncepad : MonoBehaviour
{
    private float bounce=16f;

    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*bounce,ForceMode2D.Impulse);
        }
    }
}
