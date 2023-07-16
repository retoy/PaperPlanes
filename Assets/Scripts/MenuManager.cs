using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartButtonPressed()
    {
        SceneManager.LoadScene("Game");
    }

    public void EndButtonPressed()
    {
        Application.Quit();
#if UNITY_EDITOR
        Debug.Log("Application closed.");
#endif
    }
}
