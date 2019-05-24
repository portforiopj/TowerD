using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_state : MonoBehaviour
{
    public GameObject UI_Wimage;
    public GameObject UI_quitpanel;
    public GameObject UI_mainpanel;
    public GameObject UI_wpanel;
    public Image UI_Main_image;
    public GameObject Tuto_image_empty;
    public GameObject[] UI_tuto_image;
    public GameObject[] UI_tuto_button;
    private int Tu_count = 0;
    private Text[] UI_quit_text = new Text[2];
    void Start()
    {
       
        UI_quit_text[0] = UI_quitpanel.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        UI_quit_text[1] = UI_quitpanel.transform.GetChild(1).GetChild(0).GetComponent<Text>();
        UI_MainManager2.Instatce.AttendPresent();
        if(GameObject.Find("GameSystem") != null)
        {
            GameSystem.Instatce.G_wave = 0;
            GameSystem.Instatce.G_state = GameSystem.GameState.Ready;
        }
        if (UI_MainManager2.Instatce.Tutorial)
        {
            Tuto_image_empty.SetActive(true);
            for (int i = 0; i < UI_tuto_image.Length;i++)
            {
                UI_tuto_image[i].SetActive(true);
            }   
            
        }

    }
   
    public void TutorialPlay()
    {
        if (UI_MainManager2.Instatce.Tutorial)
        {
            Tuto_image_empty.transform.GetChild(15).gameObject.SetActive(false);
            Tuto_image_empty.transform.GetChild(Tu_count).gameObject.SetActive(false);
            UI_tuto_image[Tu_count].SetActive(false);
            UI_tuto_image[Tu_count + 1].transform.SetAsLastSibling();
            UI_tuto_button[Tu_count].transform.SetAsLastSibling();
            Tu_count++;
            UI_tuto_image[Tu_count].SetActive(true);


            Tuto_image_empty.transform.GetChild(Tu_count).gameObject.SetActive(true);
        }
       
    }   
    public void SkipTuto()
    {
        UI_MainManager2.Instatce.Tutorial = false;
        PlayerPrefs.SetInt("Tutorial", 1);
        for(int i = 0; i < UI_tuto_image.Length; i++)
        {
            UI_tuto_image[i].SetActive(false);
        }
        Tuto_image_empty.SetActive(false);
    }
    public void CashChange(int i)
    {
        if (UI_MainManager2.Instatce.UI_Cash >= 50)
        {
            UI_MainManager2.Instatce.UI_Cash -= 50;
            if (i == 0)
            {
                UI_MainManager2.Instatce.UI_Gold += 1000;
                UI_MainManager2.Instatce.ResultText(UI_MainManager2.Instatce.UI_failtext, "구매가 완료되었습니다");
               
            }
            if (i == 1)
            {
                UI_MainManager2.Instatce.UI_PlayGold += 20;
                UI_MainManager2.Instatce.ResultText(UI_MainManager2.Instatce.UI_failtext, "구매가 완료되었습니다");
               
            }
        }
        else UI_MainManager2.Instatce.ResultText(UI_MainManager2.Instatce.UI_failtext, "보석이 부족합니다.");
    }
    public void ReturnMain(GameObject Panel)
    {
        if (UI_wpanel.activeSelf&&Panel.name !=UI_wpanel.name)
        {
            Panel.SetActive(false);
            return;
        }
        if (Panel.name == "UPP")
        {
            Panel.transform.GetChild(0).gameObject.SetActive(false);
        }
        UI_mainpanel.SetActive(true);
        UI_Main_image.color = new Color32(255, 255, 255, 255);
        Panel.SetActive(false);
        UI_mainpanel.SetActive(true);
        UI_Main_image.color = new Color32(255, 255, 255, 255);

        Panel.SetActive(false);
       
    }
    public void OpenP(GameObject panel)
    {
        panel.SetActive(true);
        
    }
    public void CancelB(GameObject Panel)
    {
        Panel.SetActive(false);
    }
    void Update()
    {
        UI_MainManager2.Instatce.AttendPresent();
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {

                UI_quitpanel.SetActive(true);
                UI_quit_text[0].text = "취소";
                UI_quit_text[1].text = "종료";
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {

            UI_quitpanel.SetActive(true);
            UI_quit_text[0].text = "취소";
            UI_quit_text[1].text = "종료";
        }

    }

   public void OpenPanel(GameObject Panel)
    {
        Panel.SetActive(true);
        if(Panel.name == "WPanel")
        {
            UI_Wimage.SetActive(true);
        }
        UI_mainpanel.SetActive(false);
        UI_Main_image.color = new Color32(255, 107, 107, 50);
    }
}
