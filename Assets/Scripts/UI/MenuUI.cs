using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
     [SerializeField] private GameObject menuPrefab;

     private GameObject menuPanel;

    private void Awake()
    {
        menuPanel = Instantiate(menuPrefab,transform);
        menuPanel.SetActive(true);
    }
}
