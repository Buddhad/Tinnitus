using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]GameObject quitDialog;
    public void PlayGame(){
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        SceneManager.LoadScene("Demo");
    }
    public void QuitGame()
    {
        quitDialog.SetActive(true);
    }

    public void LevelScene()
    {
    SceneManager.LoadScene("LevelSelection");
    }
    public void YesExit(){
        Application.Quit();
    }
    public void NoExit(){
    quitDialog.SetActive(false);
}

}
