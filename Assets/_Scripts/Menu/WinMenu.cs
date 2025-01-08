using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    //[SerializeField]GameObject _winMenu;
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1); //Cuz i added +1 so the index will be +1 so the next scene will show
        Time.timeScale = 1;
    }
    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void Restart()
    {
        /*
        ```summery
        Cuz of GetActiveScene function the scene will be in exact same scene where game is going on and build index
        so the game will restart at same level that you are present
        ```
        */
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

}
