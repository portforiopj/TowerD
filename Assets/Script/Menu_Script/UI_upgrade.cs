using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Upgrade
{
    [SerializeField]
    public int[] Character;

    public int GetList(int index)
    {
        return Character[index];
    }
    public int GetLength()
    {
        return Character.Length;
    }
    public void Getint(int index , string name)
    {
        Character[index] = PlayerPrefs.GetInt(name);
    }
    public void Setint(int index, string name)
    {
        PlayerPrefs.SetInt(name, Character[index]);
    }
}
public class UI_upgrade : MonoBehaviour
{
    public Image[] UI_P_images;
    public Image UI_P_image;
    public Text UI_P_status;
    public Text[] UI_up_text;
    public Text[] UI_up_gold_text;
    public GameObject UI_UPPanal;
    public int UI_choice = 0;
    public Upgrade[] UI_up_grade;
    public Button[] UI_PC;
    Player[] UI_player;
    void Start()
    {
        for (int i = 0; i < UI_PC.Length; i++)
        {
            UI_PC[i].image.sprite = GameObject.Find("Player").transform.GetChild(i).GetComponent<Player>().P_sprite;
        }

        UI_player = GameObject.Find("Player").GetComponentsInChildren<Player>();
        for(int i=0; i < UI_P_images.Length; i++)
        {
            UI_P_images[i].sprite = UI_player[i].P_sprite;
        }
        
      
        SetUpgrade();
    }
    void ShowUpgrade()
    {
        UI_P_image.sprite = UI_player[UI_choice].P_sprite;
        UI_P_status.text = UI_player[UI_choice].P_name;
       
        for(int i=0; i < 3; i++)
        {
            UI_up_text[i].text = "현재 단계 : " + (UI_up_grade[UI_choice].GetList(i) + 1).ToString() + " 초기 자원 획득량 : " + UI_up_grade[UI_choice].GetList(i).ToString() +
            "\n다음 단계 : " + (UI_up_grade[UI_choice].GetList(i) + 2).ToString() + " 초기 자원 획득량 : " + (UI_up_grade[UI_choice].GetList(i) + 1).ToString();
            if(UI_up_grade[UI_choice].GetList(i) > 9)
            {
                UI_up_text[i].text = "현재 단계 : " + (UI_up_grade[UI_choice].GetList(i) + 1).ToString() + " 초기 자원 획득량 : " + UI_up_grade[UI_choice].GetList(i).ToString() + "\n 강화가 최대 단계 입니다.";
            }
        }
        UI_up_text[3].text = "현재 단계 : " + (UI_up_grade[UI_choice].GetList(3) + 1).ToString() + " 젠 시간당 자원 회복량 : " + (UI_up_grade[UI_choice].GetList(3) + 1).ToString()
            +"\n다음 단계 : " + (UI_up_grade[UI_choice].GetList(3) + 2).ToString() + " 젠 시간당 자원 획득량: " + (UI_up_grade[UI_choice].GetList(3) + 2).ToString();;
        if(UI_up_grade[UI_choice].GetList(3) > 9)
        {
            UI_up_text[3].text = "현재 단계 : " + (UI_up_grade[UI_choice].GetList(3) + 1).ToString() + " 초기 자원 획득량 : " + UI_up_grade[UI_choice].GetList(3).ToString() + "\n 강화가 최대 단계 입니다.";
        }     
        UI_up_text[4].text = "현재 단계 : " + (UI_up_grade[UI_choice].GetList(4) + 1).ToString() + " 젠 시간 : " + (2.5f - (UI_up_grade[UI_choice].GetList(4) * 0.1)).ToString()+
           " \n다음 단계 : " + (UI_up_grade[UI_choice].GetList(4) + 2).ToString() + " 젠 시간: " + (2.5f - ((UI_up_grade[UI_choice].GetList(4) + 1) * 0.1)).ToString();;
        if(UI_up_grade[UI_choice].GetList(4) > 9)
        {
            UI_up_text[4].text = "현재 단계 : " + (UI_up_grade[UI_choice].GetList(4) + 1).ToString() + " 초기 자원 획득량 : " + UI_up_grade[UI_choice].GetList(4).ToString() + "\n 강화가 최대 단계 입니다.";
        }
        for(int i=0; i < UI_up_gold_text.Length; i++)
        {
            UI_up_gold_text[i].text = (UI_up_grade[UI_choice].Character[i] * 150+150).ToString();
        }
    }
    void SetUpgrade()
    {
        for (int j = 0; j < UI_up_grade.Length; j++)
        {
            for (int i = 0; i < UI_up_grade[j].Character.Length; i++)
            {
                UI_up_grade[j].Getint(i, UI_player[j].P_name + i);
            }
        }
    }
    public void ChoiceC(int i)
    {
        UI_choice = i;
        UI_UPPanal.SetActive(true);
        ShowUpgrade();
    }
    public void PlayerUpgrade(int i)
    {
        if(UI_MainManager2.Instatce.UI_Gold >= UI_up_grade[UI_choice].Character[i] * 150+150)
        {
            if (UI_up_grade[UI_choice].Character[i] < 9)
            {
                UI_up_grade[UI_choice].Character[i]++;
                UI_up_grade[UI_choice].Setint(i, UI_player[UI_choice].P_name + i);
                ShowUpgrade();
            }
            UI_MainManager2.Instatce.UI_Gold -= (UI_up_grade[UI_choice].Character[i] * 150+150);
        }
       
       
    }
}
