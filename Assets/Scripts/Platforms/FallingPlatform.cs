using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rbody;
    Vector2 initialPosition;
    bool platformMovingBack;
    
    void Start()
    {
        rbody=GetComponent<Rigidbody2D>();
        initialPosition=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(platformMovingBack){
            transform.position=Vector2.MoveTowards(transform.position,initialPosition,20f*Time.deltaTime);
        }
        if(transform.position.y==initialPosition.y){
            platformMovingBack=false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.name.Equals("Player")&& !platformMovingBack){
            Invoke("DropPlatform",0.7f);
        }
    }
    private void DropPlatform(){
        rbody.isKinematic=false;
        Invoke("GetPlatformBack",1f);
    }
    
    private void GetPlatformBack(){
        rbody.velocity=Vector2.zero;
        rbody.isKinematic=true;
        platformMovingBack=true;
    }
}
