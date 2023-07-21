using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public void OnHomeButtonClick() => SceneManager.LoadScene("Menu");
    public void OnRestartButtonCLick() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    public void OnNextButtonClick()
    {
        MenuController.SelectedLevel++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
