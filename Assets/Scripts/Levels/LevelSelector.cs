using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class LevelSelector : MonoBehaviour
{
    public int level;
    public TextMeshProUGUI levelText;

    private void Start() {
        levelText.text=level.ToString();
    }
    public void OpenScene(){
        SceneManager.LoadScene("Level-"+level.ToString());
    }
}
