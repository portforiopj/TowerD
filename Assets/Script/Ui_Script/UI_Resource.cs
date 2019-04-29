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
    //현재 선택한 자원 생성 값
    public string UIres_CurrentResource;


    void Start()
    {
        UIres_Effet.transform.position = UIres_tr[0].position;  // Effect의 transform Default 값
        UIres_CurrentResource = "Red";  // 생성하는 자원 변경에 쓰일 string  Default 값
    }

    
    void Update()
    {
        if(GameSystem.Instatce.G_state== GameSystem.GameState.Play)
        {
            UI_time += Time.deltaTime;
            if (UI_time > 3f)
            {
                UI_time = 0;
                GameSystem.Instatce.G_gold[UI_goldgen] += 5;
            }
        }
        if (GameSystem.Instatce.G_state != GameSystem.GameState.Play)
        {
            UI_time = 0;
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
        UI_goldgen = i;


    }
  
}
