using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isOpen;
    public Animator anim;
    public void OpenDoor(GameObject obj)
    {
        if (!isOpen)
        {
            KeyHolder holder = obj.GetComponent<KeyHolder>();
            if (holder)
            {
                if (holder.keyCount > 0)
                {
                    //Debug.Log("Open Door through key");
                    isOpen = true;
                    holder.UseKey();//used a key
                    anim.SetBool("IsOpen",isOpen);
                    
                }
            }
        }

    }
}
