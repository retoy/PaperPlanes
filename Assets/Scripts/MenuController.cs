using System.ComponentModel.Design;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject[] LevelButtons;

    public void Start()
    {
        CountLevels();
        OpenAvailableLevels();
    }

    private void CountLevels()
    {
        int levelsCount = 0;
        string[] jsonFile = Directory.GetFiles(Application.dataPath + "/Resources","*.json");
        foreach(string json in jsonFile) 
            levelsCount++;

        GameStatus.LastLevel = levelsCount;
    }

    private void OpenAvailableLevels()
    {
        for(int i = 1; i < GameStatus.LastLevel; i++)
        {
            if(PlayerPrefs.HasKey($"Level {i}"))
            {
                LevelButtons[i].GetComponent<Button>().interactable = true;
            }
        }
    }

    public void OnStartButtonClick(int level)
    {
        GameStatus.CurrentLevel = level;
        SceneManager.LoadScene("Game");
    }
    public void OnDeleteButtonClick()
    {
        PlayerPrefs.DeleteAll();
    }
}
