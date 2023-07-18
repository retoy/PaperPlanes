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
        FillBoard(CreateMatrix());
    }
    private int[,] CreateMatrix()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("LvlInfo");
        lvlInfo = JsonUtility.FromJson<LvlInfo>(jsonFile.text);

        int[,] matrix = new int[lvlInfo.rows, lvlInfo.columns];

        for(int i = 0; i < lvlInfo.rows; i++)
            for(int j = 0; j < lvlInfo.columns; j++)
                matrix[i, j] = lvlInfo.array[i * lvlInfo.columns + j];
            
        return matrix;
    }

    private void FillBoard(int[,] matrix)
    {
        for(int i = 0; i < matrix.GetLength(0); i++)
            for(int j = 0; j < matrix.GetLength(1); j++)
            {
                GameObject gem = Instantiate(gems[matrix[i, j]], new Vector3(j, i, 0), Quaternion.identity, this.GameObject().transform); 
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