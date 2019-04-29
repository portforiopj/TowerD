using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Resource : MonoBehaviour
{

    //선택한 자원 표시 이펙트
    public GameObject UIres_Effet;

    //자원 클릭 시 이펙트 이동 시킬 transform 값
    public Transform UIres_RedTr;
    public Transform UIres_BlueTr;
    public Transform UIres_GreenTr;

    //현재 선택한 자원 생성 값
    public string UIres_CurrentResource;


    void Start()
    {
        UIres_Effet.transform.position = UIres_RedTr.position;  // Effect의 transform Default 값
        UIres_CurrentResource = "Red";  // 생성하는 자원 변경에 쓰일 string  Default 값
    }

    
    void Update()
    {
        
    }

    public void ClickRed()  //빨간거 선택
    {
        UIres_Effet.transform.position = UIres_RedTr.position;  //transform 값으로 이동
        UIres_CurrentResource = "Red";  // 생성하는 자원 변경에 쓰일 string 값 변경

        //test
        Debug.Log(UIres_CurrentResource);
    }

    public void ClickBlue() //파란거 선택
    {
        UIres_Effet.transform.position = UIres_BlueTr.position;
        UIres_CurrentResource = "Blue";

        //test
        Debug.Log(UIres_CurrentResource);
    }

    public void ClickGreen()    //초록색 선택
    {
        UIres_Effet.transform.position = UIres_GreenTr.position;
        UIres_CurrentResource = "Green";

        //test
        Debug.Log(UIres_CurrentResource);
    }
}
