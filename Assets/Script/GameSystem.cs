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
    public GameObject G_mapfile;
    public Text G_time_text;
    public GameState G_state;
    public GameObject G_tower_info;
    public Text G_fail_text; // 실패 텍스트
    public bool G_playing = false;
    public int G_round; // 라운드 수
    public int G_wave; // 웨이브 수
    public int[] G_roundunit; // 나오는 유닛 수
    public float G_roundgen; // 유닛 나오는 시간
    public int G_count = 0;
    public int[] G_gold = new int[3];
    public int[] G_usegold = new int[3];
    public float[] G_goldtime = new float[3];
    public int[] G_goldcount = new int[3];
    float G_time;
    float G_time2;
    public float G_oritime;
    public float G_oritime2;
   
    void Awake()
    {
        G_state = GameState.Ready;
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
        G_round = PlayerPrefs.GetInt("Round");
        for(int i=0; i < G_mapfile.transform.childCount; i++)
        {
            G_mapfile.transform.GetChild(i).gameObject.SetActive(false);
        }
        
        G_mapfile.transform.GetChild(G_round).gameObject.SetActive(true);
        G_wave = 0;
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
        G_goldtime[0] += Time.deltaTime;
        G_goldtime[1] += Time.deltaTime;
        G_goldtime[2] += Time.deltaTime;

        UpdateGold();

    }
    void UpdateGold()
    {
        if (0.15f <= G_goldtime[0])
        {
            if(G_usegold[0] < G_goldcount[0])
            {
                G_gold[0] -= 1;
                G_goldcount[0]--;
                G_goldtime[0] = 0;
            }
            if (G_usegold[0] > G_goldcount[0])
            {
                G_gold[0] += 1;
                G_goldcount[0]++;
                G_goldtime[0] = 0;
            }
            if (G_usegold[0] == G_goldcount[0])
            {
                G_usegold[0] = 0;
                G_goldcount[0] = 0;
                G_goldtime[0] = 0;
            }
        }
        if (0.15f <= G_goldtime[1])
        {
            if (G_usegold[1] <G_goldcount[1])
            {
                G_gold[1] -= 1;
                G_goldcount[1]--;
                G_goldtime[1] = 0;
            }
            if (G_usegold[1] > G_goldcount[1])
            {
                G_gold[1] += 1;
                G_goldcount[1]++;
                G_goldtime[1] = 0;
            }
            if (G_usegold[1] == G_goldcount[1])
            {
                G_usegold[1] = 0;
                G_goldcount[1] = 0;
                G_goldtime[1] = 0;
            }
        }
        if (0.15f <= G_goldtime[2])
        {
            if (G_usegold[2] < G_goldcount[2])
            {
                G_gold[2] -= 1;
                G_goldcount[2]--;
                G_goldtime[2] = 0;
            }
            if (G_usegold[2] > G_goldcount[2])
            {
                G_gold[2] += 1;
                G_goldcount[2]++;
                G_goldtime[2] = 0;
            }
            if (G_usegold[2] == G_goldcount[2])
            {
                G_usegold[2] = 0;
                G_goldcount[2] = 0;
                G_goldtime[2] = 0;
            }
        }
    }
    void ReadyGame()
    {
        G_time_text.text = G_state.ToString()+" : " + G_time.ToString("F0"); 
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
        G_time_text.text = G_state.ToString() + " : " + G_time2.ToString("F0");
        G_time2 -= Time.deltaTime;
        if (!G_playing)
        {

            InvokeRepeating("StartRound", 0.0f,G_roundgen);
            
        }
        if(G_count == G_roundunit[G_round*6+G_wave])
        {
            G_wave++;
           
            G_count = 0;
            CancelInvoke("StartRound");
        }
        if(G_time2<=0)
        {
            G_time2 = G_oritime2;
            G_state = GameState.Ready;
            if (G_wave == 6)
            {
                G_round++;
                G_wave = 0;
                PlayerPrefs.SetInt("Round", G_round);
                SceneManager.LoadScene(0);
            }
        }
        if ((G_round * 6) + G_wave >= G_monsterctrl.M_monster_ob.Length)
        {
            G_state= GameState.Clear;
        }
      
    }
    void Clear()
    {
        PlayerPrefs.SetInt("Round", 0);
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
        PlayerPrefs.SetInt("Round", 0);
        // 게임 종료
    }
}

