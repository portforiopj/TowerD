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
    // Start is called before the first frame update
    void Awake()
    {
        
    }
    public void ReStartGame()
    {
        UI_quitpanel.SetActive(false);
    }
    public void QuitGame()
    {
        SceneManager.LoadScene(1);
    }
    void Start()
    {
        GameSystem.Instatce.G_gold[0] = 0;
        GameSystem.Instatce.G_gold[1] = 0;
        GameSystem.Instatce.G_gold[2] = 0;
        for(int i=0; i < UI_mapstage.Length; i++)
        {
            UI_mapstage[i].SetActive(false);
        }
        UI_mapstage[GameSystem.Instatce.G_Stage].SetActive(true);
        UI_mapfile = UI_mapstage[GameSystem.Instatce.G_Stage];
        for (int i = 0; i < UI_mapfile.transform.childCount; i++)
        {
            UI_mapfile.transform.GetChild(i).gameObject.SetActive(false);
        }

        UI_mapfile.transform.GetChild(GameSystem.Instatce.G_round).gameObject.SetActive(true);
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
                GameSystem.Instatce.G_wave++;

                GameSystem.Instatce.G_count = 0;
                CancelInvoke("StartRound");
            }
            UI_time_text.text = GameSystem.Instatce.G_state.ToString() + " : " + GameSystem.Instatce.G_time2.ToString("F0");
        }
        GameSystem.Instatce.UpdateGold();

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {

                UI_quitpanel.SetActive(true);             
            }
        }
        
    }
}
