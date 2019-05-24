using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class UI_Resources : MonoBehaviour
{
    public Text[] R_texts;
    public Text W_text;
    
    public Text[] UI_attend_re_text;
    public Text[] UI_attend_va_text;
    public Text[] UI_attend_co_text;
    void Start()
    {
        UI_MainManager2.Instatce.UI_attend_panel = GameObject.Find("Canvas").transform.GetChild(9).gameObject;
    }
    void ActiveMap()
    {
        GameObject a = GameObject.Find("Canvas");
        if (a.transform.GetChild(1).gameObject.activeSelf)
        {
            W_text.text = "메인 메뉴";
        }
        if (a.transform.GetChild(2).gameObject.activeSelf)
        {
            W_text.text = "월드맵";
        }

        if (a.transform.GetChild(4).gameObject.activeSelf)
        {
            W_text.text = "업그레이드";
        }
        if (a.transform.GetChild(5).gameObject.activeSelf)
        {
            W_text.text = "타워 관리";
        }
    }
    void Update()
    {
        ActiveMap();
        R_texts[0].text = UI_MainManager2.Instatce.UI_Gold.ToString();
        R_texts[1].text = UI_MainManager2.Instatce.UI_PlayGold.ToString() + "  /  10";
        R_texts[2].text = UI_MainManager2.Instatce.UI_Cash.ToString();
        if (UI_MainManager2.Instatce.UI_PlayGold >= 10)
        {
            UI_MainManager2.Instatce.R_time = 0;
            UI_MainManager2.Instatce.R_time2 = 0;
        }
        if (UI_MainManager2.Instatce.UI_PlayGold < 10)
        {
            R_texts[3].enabled = true;
            UI_MainManager2.Instatce.R_time += Time.deltaTime;
            UI_MainManager2.Instatce.Timer = (5 - UI_MainManager2.Instatce.R_time2).ToString() + ":" + (60 - UI_MainManager2.Instatce.R_time).ToString("F0");
            if (UI_MainManager2.Instatce.R_time > 60f)
            {
                UI_MainManager2.Instatce.R_time -= 60f;
                UI_MainManager2.Instatce.R_time2++;
            }
            if (UI_MainManager2.Instatce.R_time2 == 6)
            {
                UI_MainManager2.Instatce.R_time2 = 0;
                UI_MainManager2.Instatce.UI_PlayGold++;
            }
            R_texts[3].text = UI_MainManager2.Instatce.Timer;
        }
        else R_texts[3].enabled = false;

        UI_MainManager2.Instatce.AttendPresent();
    }
}

