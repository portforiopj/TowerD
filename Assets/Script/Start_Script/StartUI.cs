using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartUI : MonoBehaviour
{

    public void StartMenu()
    {
        PlayerPrefs.SetInt("Scene", 0);
        PlayerPrefs.SetInt("LoadScene", 1);
        SceneManager.LoadScene(3);
       
     
    }
}
