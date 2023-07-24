using UnityEngine;

public class ProgressController : Singleton<ProgressController>
{
    public enum LevelStatus
    {
        NotAvailable,
        Available,
        Passed,
    }

    public void MarkLevelPassed(int levelIndex, int stars)
    {
        PlayerPrefs.SetInt($"Level {levelIndex}", stars);
        PlayerPrefs.Save();
    }

    public bool IsLevelPassed(int levelIndex)
    {
        return PlayerPrefs.HasKey($"Level {levelIndex}");
    }

    public LevelStatus GetLevelStatus(int levelIndex)
    {
        return LevelStatus.Available;
    }
}