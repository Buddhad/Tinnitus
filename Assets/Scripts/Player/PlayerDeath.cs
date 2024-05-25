using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D rbody;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        rbody=GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Trap")){
            Die();
        }
    }
    private void Die(){
        anim.SetTrigger("death");
        rbody.bodyType=RigidbodyType2D.Static;
    }


}
