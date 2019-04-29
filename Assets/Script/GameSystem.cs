using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// 게임 시스템 싱글톤
public class GameSystem : MonoBehaviour
{
    public MonsterCtrl G_monsterctrl;
    public enum GameState
    {
        Ready,
        Play,
        Gameover,
        Clear
    }
    static GameSystem instance;
    public static GameSystem Instatce
    {
        get{
            return instance;
        }
    }

    public GameState G_state;
    public GameObject G_tower_info;
    public Text G_fail_text; // 실패 텍스트
    public Image G_tower_infosprite;
    public Text[] G_tower_infotext;
    public GameObject G_tower_infopanel;
    public bool G_playing = false;
    public int G_round; // 라운드 수
    public int G_wave; // 웨이브 수
    public int[] G_roundunit; // 나오는 유닛 수
    public float G_roundgen; // 유닛 나오는 시간
    public int G_count = 0;
    public int[] G_gold = new int[3];
    float G_time;
    float G_time2;
    public float G_oritime;
    public float G_oritime2;
    public void TowerOpenState(bool tower)
    {
        G_tower_infopanel.SetActive(tower);
        G_tower_infosprite.sprite = G_tower_info.GetComponent<Tower>().T_sprite;
        G_tower_infotext[0].text = G_tower_info.GetComponent<Tower>().T_name;
        G_tower_infotext[1].text = G_tower_info.GetComponent<Tower>().T_hp.ToString();
        G_tower_infotext[2].text = G_tower_info.GetComponent<Tower>().T_dmg.ToString();
        G_tower_infotext[3].text = G_tower_info.GetComponent<Tower>().T_Dmr.ToString();
        G_tower_infotext[4].text = G_tower_info.GetComponent<Tower>().T_Ats.ToString();
        G_tower_infotext[5].text = G_tower_info.GetComponent<Tower>().T_buygold.ToString();
    }
   
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        G_time = G_oritime;
        G_time2 = G_oritime2;
    }
    //public void GameStart(GameObject gameObject)
    //{
    //    bool Starting = false; // 시작 상태 bool 값
    //    if(G_state != GameState.Ready)
    //    {
    //        Starting = false;
    //    }
    //    if (G_state == GameState.Ready)
    //    {
    //        Starting = true;
    //    }
    //    if(Starting)
    //    G_state = GameState.Play;
    //}
   public void NumSentNode(int i)
    {
        Node.N_num = i;
    }
    public IEnumerator ResultText(Text text,string String)
    {
        text.enabled =true;
        text.text = String;
        yield return new WaitForSeconds(1.2f);
        text.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void GamePlayState(GameState state) // 게임 상태 
    {

        switch (state)
        {

            
            case GameState.Ready:
                ReadyGame();
                break;
            case GameState.Play:
                PlayGame();
                break;
            case GameState.Gameover:
                GameOver();
                break;
            case GameState.Clear:
                Clear();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GamePlayState(G_state);
        if (Player.P_hp <= 0)
        {
            G_state = GameState.Gameover;
        }
    }
    void ReadyGame()
    {
        G_time -= Time.deltaTime;
        if(G_time <= 0)
        {
            G_playing = false;
            G_time =G_oritime;
            G_state = GameState.Play;
        }
        // 게임 시작 전
        
    }
    void StartRound()
    {
        G_monsterctrl.StartRound();
    }
    void PlayGame()
    {
        
        G_time2 -= Time.deltaTime;
        if (!G_playing)
        {
            Debug.Log("");
            InvokeRepeating("StartRound", 0.0f,G_roundgen);
            
        }
        if(G_count == G_roundunit[(G_round*6)+G_wave])
        {
            G_wave++;
            if(G_wave == 6)
            {
                G_round++;
                G_wave = 0;
            }
            G_count = 0;
            CancelInvoke("StartRound");
        }
        if(G_time2<=0)
        {
            G_time2 = G_oritime2;
            G_state = GameState.Ready;
        }
        if ((G_round * 6) + G_wave >= G_monsterctrl.M_monster_ob.Length)
        {
            G_state= GameState.Clear;
        }
      
    }
    void Clear()
    {
        SceneManager.LoadScene(2);
    }
    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        
    }
    public void PauseGame()
    {
        Time.timeScale =0f;
        //시작 버튼 정지
    }
    void GameOver()
    {
       
        // 게임 종료
    }
}

