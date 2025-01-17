using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            StartCoroutine(LoadScene());
        }
        
    }




    IEnumerator LoadScene(){
            transitionAnim.SetTrigger("end");
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(sceneName);
        }
}
