using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_state : MonoBehaviour
{

    public GameObject UI_quitpanel;
    Text[] UI_quit_text = new Text[2];
    void Start()
    {
        UI_quit_text[0] = UI_quitpanel.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        UI_quit_text[1] = UI_quitpanel.transform.GetChild(1).GetChild(0).GetComponent<Text>();

    }
    
    public void CancelB()
    {
        UI_quitpanel.SetActive(false);
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
}
