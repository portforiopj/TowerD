using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterChoice : MonoBehaviour
{
    
    public GameObject CC_choicepanal;
    public void GameStart(int i)
    {
        PlayerPrefs.SetInt("Stage",i);
        GameObject a = GameObject.Find("Canvas");
 
        a.transform.GetChild(1).gameObject.SetActive(false);
        CC_choicepanal.SetActive(true);
        
    }
    public void Back()
    {
        GameObject a = GameObject.Find("Canvas");

        a.transform.GetChild(1).gameObject.SetActive(true);
        CC_choicepanal.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void CharcterChoiceAct(int i)
    {
        if (UI_MainManager2.Instatce.UI_PlayGold > 0)
        {
            if (i > 1)
            {
                i = 0;
            }
            UI_MainManager2.Instatce.UI_PlayGold--;
            PlayerPrefs.SetInt("Round", 0);
            PlayerPrefs.SetInt("Character", i);
            PlayerPrefs.SetInt("Scene", 1);
            PlayerPrefs.SetInt("LoadScene", 2);
            SceneManager.LoadScene(3);

        }
        else StartCoroutine(UI_MainManager2.Instatce.ResultText(UI_MainManager2.Instatce.UI_failtext, "행동력이 부족합니다."));
        
    }
}
