using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using System;

public class LVLLoader : MonoBehaviour
{
    [SerializeField] private GameObject[] gems;
    private LvlInfo lvlInfo;

    void Start()
    {
        FillBoard(MenuController.SelectedLevel);
    }
    private void FillBoard(int selectedLvl)
    {                                                
        TextAsset jsonFile = Resources.Load<TextAsset>("LVL" + selectedLvl);
        if (jsonFile)
        {
            lvlInfo = JsonUtility.FromJson<LvlInfo>(jsonFile.text);

            for(int i = 0; i < lvlInfo.rows; i++)
                for(int j = 0; j < lvlInfo.columns; j++)
                {
                    GameObject gem = Instantiate(gems[lvlInfo.array[i * lvlInfo.columns + j]],
                                                 new Vector3(j - 1.5f, i - 1, 0),
                                                 Quaternion.identity,
                                                 this.GameObject().transform);
                }
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