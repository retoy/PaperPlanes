using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject level;

    public void OnStartButtonClick ()
    {
        menu.SetActive (false);
        level.SetActive (true);
    }
}
