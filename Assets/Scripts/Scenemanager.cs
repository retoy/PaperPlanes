using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{

    public void changeScene(int sceneid)
    {
        SceneManager.LoadScene(sceneid);
    }
}
