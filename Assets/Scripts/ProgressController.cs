using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressController : MonoBehaviour
{
    public void OnWinButtonClick(int starsAmount)
    {
        SaveLevelProgress(starsAmount);
        SaveLevelProgress(starsAmount);       
    }
    private void SaveLevelProgress(int starsAmount)
    {
        PlayerPrefs.SetInt($"Level {GameStatus.CurrentLevel}", starsAmount);
        PlayerPrefs.Save();
    }
}
