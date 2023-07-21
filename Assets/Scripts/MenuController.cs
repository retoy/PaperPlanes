using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static int SelectedLevel;

    public void OnStartButtonClick(int level)
    {
        SelectedLevel = level;
        SceneManager.LoadScene("Game");
    }
}
