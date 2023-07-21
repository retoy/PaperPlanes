using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static int CurrentLevel;
    public static int LastLevel;

    public void Start()
    {
        CountLevels();
    }

    private void CountLevels()
    {
        int levelsCount = 0;
        string[] jsonFile = Directory.GetFiles(Application.dataPath + "/Resources","*.json");
        foreach(string json in jsonFile) 
            levelsCount++;

        LastLevel = levelsCount;
    }
    public void OnStartButtonClick(int level)
    {
        CurrentLevel = level;
        SceneManager.LoadScene("Game");
    }
}
