using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_MainManger : MonoBehaviour
{
    public Text UI_fail_text; // 실패 텍스트
    public GameObject UI_mapfile;
    public Text UI_time_text;
    public MonsterCtrl UI_monsterctrl;
    public GameObject[] UI_mapstage;
    public GameObject UI_quitpanel;
    public Player UI_player;
    public GameObject UI_FailPanel;
    public GameObject UI_ClearPanel;
    public Text[] UI_gold_text;
    bool Clear = false;
    bool Die = false;
    // Start is called before the first frame update
    void Awake()
    {
        GameSystem.Instatce.G_state = GameSystem.GameState.Ready;
        GameSystem.Instatce.G_wave = 0;
        GameSystem.Instatce.G_Stage = PlayerPrefs.GetInt("Stage");

        GameSystem.Instatce.G_round = PlayerPrefs.GetInt("Round");
        GameSystem.Instatce.G_choiceint = PlayerPrefs.GetInt("Character");
        UI_mapfile = UI_mapstage[GameSystem.Instatce.G_Stage];
        GameSystem.Instatce.G_monsterctrl = GameObject.Find("MonsterCtrl").GetComponent<MonsterCtrl>();
        for (int i = 0; i < UI_mapfile.transform.childCount; i++)
        {
            UI_mapfile.transform.GetChild(i).gameObject.SetActive(false);
        }

        UI_mapfile.transform.GetChild(GameSystem.Instatce.G_round).gameObject.SetActive(true);
    }
    public void ReStartGame()
    {
        UI_quitpanel.SetActive(false);
    }
    public void RetryGame(int i)
    {

     
        GameOver();
        Die = false;
        PlayerPrefs.SetInt("LoadScene", i);
        SceneManager.LoadScene(3);      
    }
    public void RetryGame2(int i)
    {

        Clear =false;
        ClearGame();
        PlayerPrefs.SetInt("LoadScene", i);
        SceneManager.LoadScene(3);

    }
    public void GameOver()
    {
        UI_MainManager2.Instatce.UI_Gold += (GameSystem.Instatce.G_Stage+1) * ((GameSystem.Instatce.G_round * 6) + GameSystem.Instatce.G_wave);
    }
    public void ClearGame()
    {

        UI_MainManager2.Instatce.UI_Gold += ((GameSystem.Instatce.G_Stage+1) * ((GameSystem.Instatce.G_round * 6) + GameSystem.Instatce.G_wave))+ 200;
        UI_MainManager2.Instatce.UI_Cash += (GameSystem.Instatce.G_Stage+1);

    }
    
    public void QuitGame()
    {
        SceneManager.LoadScene(1);

    }

    void Start()
    {
        UI_player = GameObject.Find("Player").transform.GetChild(GameSystem.Instatce.G_choiceint).GetComponent<Player>();
       
        for(int i=0; i < UI_mapstage.Length; i++)
        {
            UI_mapstage[i].SetActive(false);
        }
        UI_mapstage[GameSystem.Instatce.G_Stage].SetActive(true);
       
    }
    void StartRound()
    {
        Tower.T_attackmonsterdie = true;
        UI_monsterctrl.StartRound();
        
        
    }
    // Update is called once per frame
    void Update()
    {
       
        if ((GameSystem.Instatce.G_round * 6) + GameSystem.Instatce.G_wave >= UI_monsterctrl.M_monster_ob.Length)
        {
            GameSystem.Instatce.G_state = GameSystem.GameState.Clear;
        }
        if (GameSystem.Instatce.G_state == GameSystem.GameState.Ready)
        {
            UI_time_text.text = GameSystem.Instatce.G_state.ToString() + " : " + GameSystem.Instatce.G_time.ToString("F0");
        }
        else if (GameSystem.Instatce.G_state == GameSystem.GameState.Play)
        {
            if (!GameSystem.Instatce.G_playing)
            {
                InvokeRepeating("StartRound", 0.0f, GameSystem.Instatce.G_roundgen);
            }
            if (GameSystem.Instatce.G_count == GameSystem.Instatce.G_roundunit[GameSystem.Instatce.G_round * 6 + GameSystem.Instatce.G_wave])
            {
                //GameSystem.Instatce.G_wave++;

                //GameSystem.Instatce.G_count = 0;
                CancelInvoke("StartRound");
            }
            UI_time_text.text = GameSystem.Instatce.G_state.ToString() + " : " + GameSystem.Instatce.G_time2.ToString("F0");
        }
        GameSystem.Instatce.UpdateGold();
        if(GameSystem.Instatce.G_state == GameSystem.GameState.Gameover)
        {
            UI_gold_text[0].text = ((GameSystem.Instatce.G_Stage+1) * ((GameSystem.Instatce.G_round * 6) + GameSystem.Instatce.G_wave)).ToString();
            UI_FailPanel.SetActive(true);
            
            Time.timeScale = 0.0f;
        }
        if (GameSystem.Instatce.G_state == GameSystem.GameState.Clear)
        {
           
            UI_gold_text[0].text = ((GameSystem.Instatce.G_Stage+1) * ((GameSystem.Instatce.G_round * 6) + GameSystem.Instatce.G_wave)+200).ToString();
            UI_ClearPanel.SetActive(true);
            Time.timeScale = 0.0f;

        }
       
        //if (Application.platform == RuntimePlatform.Android)
        //{
            if (Input.GetKey(KeyCode.Escape))
            {

                UI_quitpanel.SetActive(true);
            GameSystem.Instatce.G_state = GameSystem.GameState.Pause;
            PlayerPrefs.SetInt("Scene", 0);
            }   
        //}
        
    }
}
