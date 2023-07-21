using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public void OnHomeButtonClick() => SceneManager.LoadScene("Menu");
    public void OnRestartButtonCLick() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    public void OnNextButtonClick()
    {
        if(MenuController.CurrentLevel != MenuController.LastLevel)
        {
            MenuController.CurrentLevel++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
            SceneManager.LoadScene("Menu");

    }
}
