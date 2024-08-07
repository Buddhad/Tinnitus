using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //public static SceneController instance;
    [SerializeField]Animator transitionAnim;
/*
    public void Awake() {
        if(instance=null){
            instance=this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
        
    }
*/
    public void NextScene(){
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel(){
        transitionAnim.SetTrigger("Last");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
        transitionAnim.SetTrigger("Start");
    }
}
