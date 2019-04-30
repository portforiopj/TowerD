using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Wave : MonoBehaviour
{
    //test용 정보값
    public List<int> WaveCount = new List<int>();   //wave 횟수 용 - 웨이브 횟수 만큼 wave정보창 생성 용도

    public 
    bool UIwave_set = true;
    public GameObject UIwave_InfoPannel;    //wave정보창 prefab
    GameObject WaveInfoPanel;   //wave 정보창
    bool IsWaveInfo_ButtonState = true;    //button 위아래 올리는 애니메이션 조건 확인 bool값, true면 아래로, false면 위로 올라가는 애니메이션 실행

    public Transform UIwave_WaveContentTR;  //WaveContent 부모로 잡고 그 안에 자식으로 waveinfo panel 창 생성할 값

    void Start()
    {
        SetWaveInfo();
        for (int i = 0; i < WaveCount.Count; i++)  //웨이브 정보만큼 생성 -> 재활용으로 변경할 것 일단 생성으로 처리
        {
            WaveInfoPanel = Instantiate(UIwave_InfoPannel); //생성
            WaveInfoPanel.transform.SetParent(UIwave_WaveContentTR);    //WaveContent 부모로 잡고 그 안에 자식으로 waveinfo panel 창 생성
        }

    }

    
    void Update()
    {
        if(GameSystem.Instatce.G_state == GameSystem.GameState.Ready&&UIwave_set)
        {
            InfoSetButton();
            UIwave_set = false;
        }    
        if(GameSystem.Instatce.G_state == GameSystem.GameState.Play)
        {
            InfoSetButton();
            UIwave_set = true;
        }
    }

     void SetWaveInfo()  //웨이브 정보 패널 창 생성하는 함수
    {
        for (int i = 0; i < 6 - GameSystem.Instatce.G_wave; i++)
        {
            WaveCount.Add(i);
            if(i >= 2)
            {
                Debug.Log(WaveCount.Count);
                break;
            }
        }
        
    }
    void InfoSetButton()
    {
        
        for (int i = 0; i < WaveCount.Count; i++)
        {
            if (GameSystem.Instatce.G_round * 6 + GameSystem.Instatce.G_wave + i -3 <= GameSystem.Instatce.G_monsterctrl.M_monster_ob.Length)
            {
                transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<Image>().sprite =
   GameSystem.Instatce.G_monsterctrl.M_monster_ob[GameSystem.Instatce.G_round * 6 + GameSystem.Instatce.G_wave + i].GetComponent<Monster>().M_sprite;
                transform.GetChild(0).GetChild(i).GetChild(1).GetComponent<Text>().text = "X" +
    GameSystem.Instatce.G_roundunit[GameSystem.Instatce.G_wave + i].ToString();
            }
            else break;
        }
    }


    public void ActionwaveButton()  //waveInfo창 위아래로 열었다 닫았다 하는 버튼 함수
    {

        InfoSetButton();
        if(WaveCount.Count == 1)
        {
            return;
        }
        else if (WaveCount.Count == 2)   //wave 정보 panel 창의 갯수에 맞게끔 애니메이션 함수를 호출하기 위한 조건식
        {
            if (IsWaveInfo_ButtonState)
            {
                GetComponent<Animation>().Play("WaveInfo_down1");
                IsWaveInfo_ButtonState = false; //!IsWaveInfo_ButtonState가 true가 되서 다음 버튼 함수는 패널창이 위로 올라가게끔 한다.
            }
            else if (!IsWaveInfo_ButtonState)
            {
                GetComponent<Animation>().Play("WaveInfo_Up1");
                IsWaveInfo_ButtonState = true;  //!IsWaveInfo_ButtonState가 true가 되서 다음 버튼 함수는 패널창이 아래로 내려가게끔 한다.
            }
        }

        else if(WaveCount.Count == 3)
        {
            if (IsWaveInfo_ButtonState)
            {
                GetComponent<Animation>().Play("WaveInfo_down2");
                IsWaveInfo_ButtonState = false;
            }
            else if (!IsWaveInfo_ButtonState)
            {
                GetComponent<Animation>().Play("WaveInfo_Up2");
                IsWaveInfo_ButtonState = true;
            }
            
        }
        
    }
}
