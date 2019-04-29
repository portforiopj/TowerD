using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerInfo : MonoBehaviour
{
    //test 용도
    int blue = 1;
    int red = 1;
    int green =1;
    int PlayHp = 30;
    int PlayMhp;



    public Image UIPlay_Sprite; //초상화
    public Text UIPlay_RedText; //빨강 자원 보유 수량
    public Text UIPlay_BlueText;    //파랑 자원 보유 수량
    public Text UIPlay_GreenText;   //초록 자원 보유 수량
    public Image UIPaly_HealthBar;  //플레이어 체력바
    public Text UIPaly_HealthBarText;  //플레이어 체력바 Text

    void Start()
    {
        //뒤에 할당 값 전부 test 용
        UIPlay_RedText.text = red.ToString();        
        UIPlay_GreenText.text = green.ToString();
        UIPlay_BlueText.text = blue.ToString();
        PlayMhp = PlayHp;
    }

    
    void Update()
    {
        //test
        SetHealthBar();
    }

    public void SetHealthBar()
    {
        //test 용
        PlayHp = 10;


        UIPaly_HealthBar.fillAmount = (float)PlayHp / PlayMhp;
        UIPaly_HealthBarText.text = PlayHp + " / " + PlayMhp;
    }

}
