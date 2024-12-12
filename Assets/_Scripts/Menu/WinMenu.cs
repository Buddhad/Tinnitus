using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    //[SerializeField]GameObject _winMenu;
    public void NextLevel(){
        SceneManager.LoadScene("Level-1");
        Time.timeScale=1;
    }
    public void Home(){
        SceneManager.LoadScene("MainMenu");
        Time.timeScale=1;
    }
    
    public void Restart(){
        SceneManager.LoadScene("Demo");
        Time.timeScale=1;
    }
}
