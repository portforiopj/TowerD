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
    Text[] UI_quit_text = new Text[2];
    void Start()
    {
        UI_quit_text[0] = UI_quitpanel.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        UI_quit_text[1] = UI_quitpanel.transform.GetChild(1).GetChild(0).GetComponent<Text>();

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
    public void CancelB(GameObject Panel)
    {
        Panel.SetActive(false);
    }
    void Update()
    {
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
