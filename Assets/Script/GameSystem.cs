using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 게임 시스템 싱글톤
public class GameSystem : MonoBehaviour
{
    public MonsterCtrl G_monsterctrl;
    public enum GameState
    {
        Ready,
        Play,
        Pause,
        Gameover
    }
    static GameSystem instance;
    public static GameSystem Instatce
    {
        get{
            return instance;
        }
    }

    public GameState G_state;
    public GameObject[] G_monsters;
    public Text G_fail_text; // 실패 텍스트
    public bool G_playing;
    public int G_round; // 라운드 수
    public int G_wave; // 웨이브 수
    public int[] G_roundunit; // 나오는 유닛 수
    public float G_roundgen; // 유닛 나오는 시간
    public int[] G_gold = new int[3];
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
    }
    public void GameStart(GameObject gameObject)
    {
        bool Starting = false; // 시작 상태 bool 값
        if(G_state != GameState.Ready)
        {
            Starting = false;
        }
        if (G_state == GameState.Ready)
        {
            Starting = true;
        }
        if(Starting)
        G_state = GameState.Play;
    }
    public void NumSentNode()
    {
        Node.N_num = 5;
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

            case GameState.Play:
                PlayGame();
                break;
            case GameState.Ready:
                ReadyGame();
                break;
            case GameState.Pause:
                PauseGame();
                break;
            case GameState.Gameover:
                GameOver();
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
        // 게임 시작 전
        G_playing = true;
    }
    void PlayGame()
    {
        if (G_playing)
        {
            G_monsterctrl.StartRound();
        }
        if(G_monsterctrl.M_count == (G_roundunit[G_wave]-1))
        {
            G_state= GameState.Pause;
        }
    }
    void PauseGame()
    {
        G_monsters = GameObject.FindGameObjectsWithTag("Monster");
        if(G_monsters.Length == 0)
        {
            G_state = GameState.Ready;
        }
        //시작 버튼 정지
    }
    void GameOver()
    {
       
        // 게임 종료
    }
}

