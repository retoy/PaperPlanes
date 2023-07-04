using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{   
    [SerializeField] private GameObject gem;
    [SerializeField] private int columns, rows;    

    private GameObject[,] gems;   

    void Start()
    {    
        Vector2 center = gem.GetComponent<SpriteRenderer>().bounds.size;     
        CreateBoard(center);                                                 
    }

    private void CreateBoard(Vector2 center)
    {
        gems = new GameObject[columns, rows];  

        float boardPosX = transform.position.x;     
        float boardPosY = transform.position.y;

        for (int x = 0; x < columns; x++)
            for (int y = 0; y < rows; y++)
                gems[x, y] = Instantiate(gem, new Vector3(boardPosX + (center.x * x), boardPosY + (center.y * y), 0), Quaternion.identity);  
    }
}
