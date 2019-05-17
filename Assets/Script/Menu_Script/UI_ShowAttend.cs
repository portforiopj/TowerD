using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_ShowAttend : MonoBehaviour
{
    public GameObject[] ShowAttends;
    public Sprite[] ShowAttends_sprite;
    void OnEnable()
    {
        for (int i = 0; i < ShowAttends.Length; i++)
        {
            for (int j = 0; j < ShowAttends_sprite.Length; j++)
            {
                if (UI_MainManager2.Instatce.attends[i].resource == j)
                {
                    ShowAttends[i].GetComponent<Image>().sprite = ShowAttends_sprite[j];
                   
                    break;
                }

            }
            if (UI_MainManager2.Instatce.UI_P_attend >   i)
            {
                ShowAttends[i].GetComponent<Image>().color = new Color32(170, 170, 170, 255);
            }
            else ShowAttends[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            ShowAttends[i].transform.GetChild(1).GetComponent<Text>().text = UI_MainManager2.Instatce.attends[i].value.ToString();

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
