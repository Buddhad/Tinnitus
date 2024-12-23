using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;
    [SerializeField] float minX, maxX;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        tempPos = transform.position;
        tempPos.x = player.position.x;
        
        if (tempPos.x < minX)
        {
            tempPos.x = minX;
        }
        if (tempPos.x > maxX)
        {
            tempPos.x = maxX;
        }
        
        transform.position = tempPos;
    }
}
