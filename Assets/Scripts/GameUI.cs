using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public void HomePressedButton() => SceneManager.LoadScene("Menu");
    public void RestartPressedButton() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
