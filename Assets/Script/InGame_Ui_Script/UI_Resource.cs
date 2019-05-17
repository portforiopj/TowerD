using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Resource : MonoBehaviour
{

    //선택한 자원 표시 이펙트
    public GameObject UIres_Effet;

    //자원 클릭 시 이펙트 이동 시킬 transform 값
    public Transform[] UIres_tr;


    int UI_goldgen;
    float UI_time;
    int UI_goldgen2;
    float UI_time2 = 0;
    //현재 선택한 자원 생성 값
    public string UIres_CurrentResource;


    void Start()
    {
        UI_goldgen = 1 + GameObject.Find("Player").transform.GetChild(GameSystem.Instatce.G_choiceint).GetComponent<Player>().P_upgrade[3];
        UI_time = 2.5f - (float)(GameObject.Find("Player").transform.GetChild(GameSystem.Instatce.G_choiceint).GetComponent<Player>().P_upgrade[4] * 0.1);
        UIres_Effet.transform.position = UIres_tr[0].position;  // Effect의 transform Default 값
        UIres_CurrentResource = "Red";  // 생성하는 자원 변경에 쓰일 string  Default 값
    }

    
    void Update()
    {
        if(GameSystem.Instatce.G_state== GameSystem.GameState.Play)
        {
            UI_time2 += Time.deltaTime;
            if (UI_time <UI_time2)
            {
                UI_time2 = 0;
                GameSystem.Instatce.G_usegold[UI_goldgen2] += UI_goldgen;
            }
        }
        if (GameSystem.Instatce.G_state != GameSystem.GameState.Play)
        {
            UI_time2 = 0;
        }


    }
    public void ClickGold(int i)
    {
        UIres_Effet.transform.position = UIres_tr[i].position;
        if (i == 0)
        {
            UIres_CurrentResource = "Red";
        }
        if (i == 1)
        {
            UIres_CurrentResource = "Blue";
        }
        if (i == 2)
        {
            UIres_CurrentResource = "Green";
        }
        UI_goldgen2 = i;


    }
  
}
