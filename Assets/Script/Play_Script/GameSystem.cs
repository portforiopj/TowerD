using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// 게임 시스템 싱글톤
public class GameSystem : MonoBehaviour
{
    public MonsterCtrl G_monsterctrl;
    bool G_roundset = false;
    public enum GameState
    {
        Ready,
        Play,
        Gameover,
        Clear,
        Pause
    }
    static GameSystem instance;
    public static GameSystem Instatce
    {
        get{
            return instance;
        }
    }

    public GameState G_state;
    public int G_Stage;
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
    public float G_time;
    public float G_time2;
    public float G_oritime;
    public float G_oritime2;
    public int G_choiceint;

    void Awake()
    {
        G_state = GameState.Ready;
        if (instance != null)
        {
            Destroy(gameObject);
           
        }
        else
        {

            instance = this;
            DontDestroyOnLoad(gameObject);
           
        }
       
        G_time = G_oritime;
        G_time2 = 0;
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
    }
    public void UpdateGold()
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
        
        G_time -= Time.deltaTime;
        if(G_time <= 0)
        {
            
            G_playing = false;
            G_time =G_oritime;
            G_state = GameState.Play;
            G_roundset = false;
        }
        // 게임 시작 전
        
    }

    void PlayGame()
    {

        GameObject[] G_monsters = GameObject.FindGameObjectsWithTag("Monster");
        if (!G_roundset)
        {
            G_time2 += Time.deltaTime;
        }
        if (GameSystem.Instatce.G_count == GameSystem.Instatce.G_roundunit[GameSystem.Instatce.G_round * 6 + GameSystem.Instatce.G_wave])
        {

            if (G_monsters.Length <= 0)
            {
                G_roundset = true;
                G_state = GameState.Ready;
                G_time2 = 0;
                GameSystem.Instatce.G_wave++;

                GameSystem.Instatce.G_count = 0;
                if (G_wave == 6)
                {
                    if(G_round == 5)
                    {
                        G_state = GameState.Clear;
                        return;
                    }
                    G_round++;
                    G_wave = 0;
                    PlayerPrefs.SetInt("Round", G_round);
                    SceneManager.LoadScene(2);
                }

            }

        }
            
        
        
      
    }
    void Clear()
    {
        PlayerPrefs.SetInt("Round", 0);

    }

    void GameOver()
    {
        PlayerPrefs.SetInt("Round", 0);
        
        // 게임 종료
    }
}

