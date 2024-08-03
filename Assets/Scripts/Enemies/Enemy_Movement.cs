using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float PlateformSpeed = 3f; 

    // Update is called once per frame
    private  void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position)<.1f)
        {
            transform.localScale =new Vector3(-1,1,1);
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
                transform.localScale =new Vector3(1,1,1);
            }
            
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * PlateformSpeed);
        
    }
}
