using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("Level-1");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Check!!");
    }

    public void LevelScene()
    {
    SceneManager.LoadScene("LevelSelection");
    }

    public void Sound()
    {
        Debug.Log("Sound Check!!");
    }
    public void Music()
    {
        Debug.Log("Music Check!!");
    }



}
