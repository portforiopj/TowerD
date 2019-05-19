using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[System.Serializable]
public class Attend
{
    public int resource;
    public int value; 
    public string content;
}
public class UI_MainManager2 : MonoBehaviour
{
   
    static UI_MainManager2 instance;
    public static UI_MainManager2 Instatce
    {
        get
        {
            return instance;
        }
    }
    public int UI_Gold;
    public int UI_PlayGold;
    public int UI_Cash;
    public UI_PScriptable scriptable;
    public UI_P_Psciprtable p_Psciprtable;
    public Attend[] attends;
    
    public int UI_P_attend = 0;
    public int UI_P_attend2;
    public GameObject UI_ppanel;
    GameObject UI_panel;
    int UI_day;
    bool attended = false;
    DateTime UI_time;
    DateTime UI_time2;
    public GameObject UI_attend_panel;
    public Text UI_failtext;

    public int[] R_timer = new int[6];

    public float R_time;
    public string Timer;
    DateTime Starttime;
    DateTime Endtime;
    public int R_time2 = 0;
    public List<Attend> P_attends = new List<Attend>();

    public void test()
    {
        PlayerPrefs.SetInt("Attend", 0);
    }
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);

        }
        else
        {

            instance = this;
            DontDestroyOnLoad(gameObject);

        }
       
        UI_Gold = PlayerPrefs.GetInt("UIGold");
        UI_PlayGold = PlayerPrefs.GetInt("UIPlayGold");
        UI_Cash = PlayerPrefs.GetInt("UICash");
        R_time = PlayerPrefs.GetFloat("r_time");
        R_time2 = PlayerPrefs.GetInt("r_time2");
        R_timer[0] = PlayerPrefs.GetInt("StartYear");
        R_timer[1] = PlayerPrefs.GetInt("StartMon");
        R_timer[2] = PlayerPrefs.GetInt("StartDay");
        R_timer[3] = PlayerPrefs.GetInt("StartHour");
        R_timer[4] = PlayerPrefs.GetInt("StartMin");
        R_timer[5] = PlayerPrefs.GetInt("StartSec");

    }

    void Start()
    {
        SetAttend();
        Starttime = new DateTime(R_timer[0], R_timer[1], R_timer[2], R_timer[3], R_timer[4], R_timer[5]);
        Endtime = Convert.ToDateTime(DateTime.Now);
        TimeSpan Timecal = Endtime - Starttime;
        int timecalS = (int)Timecal.TotalSeconds;
        if (UI_PlayGold < 10)
        {
            while (timecalS > 360)
            {
                timecalS -= 360;
                UI_PlayGold++;
            }
            R_time += timecalS;
        }
        else if (UI_PlayGold >= 10)
        {
            timecalS = 0;
        }
        UI_day = PlayerPrefs.GetInt("AttendDay");
        if (UI_day == 0)
        {
            UI_time2 = Convert.ToDateTime(DateTime.Now);
            PlayerPrefs.SetInt("AttendDay", UI_time2.Day);
        }

      
       
    }
    public IEnumerator ResultText(Text text, string String)
    {
        text.gameObject.SetActive( true);
        text.text = String;
        yield return new WaitForSeconds(1.2f);
        text.gameObject.SetActive(false);
    }
    void OnApplicationQuit()
    {
       
        PlayerPrefs.SetFloat("r_time", R_time);
        PlayerPrefs.SetInt("r_time2", R_time2);
        Starttime = Convert.ToDateTime(DateTime.Now);
        PlayerPrefs.SetInt("StartDay", Starttime.Day);
        PlayerPrefs.SetInt("StartMon", Starttime.Month);
        PlayerPrefs.SetInt("StartHour", Starttime.Hour);
        PlayerPrefs.SetInt("StartMin", Starttime.Minute);
        PlayerPrefs.SetInt("StartSec", Starttime.Second);
        PlayerPrefs.SetInt("StartYear", Starttime.Year);
        PlayerPrefs.SetInt("UIGold", UI_Gold);
        PlayerPrefs.SetInt("UIPlayGold", UI_PlayGold);
        PlayerPrefs.SetInt("UICash", UI_Cash);
        PlayerPrefs.SetInt("UI_P_attend", UI_P_attend);
    }
    public void SendP(int a, int b, string c,GameObject d)
    {
        Transform tr = GameObject.Find("Canvas").transform.GetChild(7).GetChild(0).GetChild(0).GetChild(0);
        d = Instantiate(UI_ppanel,tr.position,tr.rotation);
        d.GetComponent<UI_Pinfo>().P_info_int = a;
        d.GetComponent<UI_Pinfo>().P_info_val = b;
        d.GetComponent<UI_Pinfo>().P_info_text[1].text = c;
        d.transform.SetParent(tr);
    }
    public  void AttendPresent()
    {
        UI_P_attend = PlayerPrefs.GetInt("UI_P_attend");
        UI_P_attend2 = PlayerPrefs.GetInt("Attend");
        if (UI_P_attend2 == 0)
        {
            attended = false;
        }
        else if (UI_P_attend2 == 1)
        {
            attended = true;
        }
        if (!attended)
        {
            p_Psciprtable.P_PostList.Add(attends[UI_P_attend]);
            SetAttend();
            UI_P_attend++; 
            PlayerPrefs.SetInt("Attend", 1);
            PlayerPrefs.SetInt("UI_P_attend", UI_P_attend);
            UI_attend_panel.SetActive(true);
            UI_P_attend %= 10;

        }

    }
   
    public void SetAttend()
    {

        P_attends.Clear();
        for (int i = 0; i < p_Psciprtable.P_PostList.Count; i++)
        {
            P_attends.Add(p_Psciprtable.P_PostList[i]);
        }

    }
    void Update()
    {

        AttendPresent();
        OnApplicationQuit();
        UI_time = Convert.ToDateTime(DateTime.Now);
        if (UI_day != UI_time.Day)
        {
            PlayerPrefs.SetInt("Attend", 0);
            PlayerPrefs.SetInt("AttendDay", UI_time.Day);
            UI_day = UI_time.Day;
         
            
        }
        

    }


   

}
