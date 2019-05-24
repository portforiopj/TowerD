using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerInfo : MonoBehaviour
{
    //test 용도
    
    int UI_PlayMhp;


    public Player UI_player;
    public Image UIPlay_Sprite; //초상화
    public Text UIPlay_RedText; //빨강 자원 보유 수량
    public Text UIPlay_BlueText;    //파랑 자원 보유 수량
    public Text UIPlay_GreenText;   //초록 자원 보유 수량
    public Image UIPaly_HealthBar;  //플레이어 체력바
    public Text UIPaly_HealthBarText;  //플레이어 체력바 Text

    void Start()
    {
        UI_player = GameObject.Find("Player").transform.GetChild(GameSystem.Instatce.G_choiceint).GetComponent<Player>();
        //뒤에 할당 값 전부 test 용
        Player.P_hp = 30;
        UI_PlayMhp = Player.P_hp;
        UIPlay_Sprite.sprite = UI_player.P_sprite;
    }

    
    void Update()
    {
        UIPlay_RedText.text = GameSystem.Instatce.G_gold[0].ToString();
        UIPlay_BlueText.text = GameSystem.Instatce.G_gold[1].ToString();
        UIPlay_GreenText.text = GameSystem.Instatce.G_gold[2].ToString();

        SetHealthBar();
    }

    public void SetHealthBar()
    {



        UIPaly_HealthBar.fillAmount = (float)Player.P_hp / UI_PlayMhp;
        UIPaly_HealthBarText.text = Player.P_hp + " / " + UI_PlayMhp;
    }

}
