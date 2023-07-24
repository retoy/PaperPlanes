using UnityEngine;
using UnityEngine.SceneManagement;

public class LVLLoader : MonoBehaviour
{
    [SerializeField] private GameObject board;
    [SerializeField] private GameObject[] gems;
    private LvlInfo lvlInfo;

    void Start()
    {
        FillBoard(GameStatus.CurrentLevel);
    }

    private void FillBoard(int selectedLvl)
    {
        TextAsset jsonFile = LevelsProvider.Instance.Levels[selectedLvl];
        if (jsonFile)
        {
            lvlInfo = JsonUtility.FromJson<LvlInfo>(jsonFile.text);

            for (int i = 0; i < lvlInfo.rows; i++)
            {
                for (int j = 0; j < lvlInfo.columns; j++)
                {
                    GameObject gem = Instantiate(gems[lvlInfo.array[i * lvlInfo.columns + j]],
                        new Vector3(j - 1.5f, i - 1, 0),
                        Quaternion.identity,
                        board.transform);
                }
            }
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }
}

[System.Serializable]
public class LvlInfo
{
    public int[] array;
    public int rows;
    public int columns;
}