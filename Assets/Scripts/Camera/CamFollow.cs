using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float offsetx = 1f;
    public float offsety = 1f;
    void Update()
    {
        transform.position = new Vector3(player.position.x+ offsety, player.position.y+ offsetx, transform.position.z);
    }
}
