using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 타일 노드
public class Node : MonoBehaviour
{
    public Info N_info;

    public GameObject N_instower;
    public static int N_num = 0;
    void Awake()
    {

    }
    void Update()
    {

    }

    void OnMouseDown()// 마우스 입력값을 받아 타워를 설치하고 타일의 마테리얼 변경
    {

        if (gameObject.GetComponent<MeshRenderer>().material.color == Info.Instatnce.I_node_mat[2].color ||
            gameObject.GetComponent<MeshRenderer>().material.color == Info.Instatnce.I_node_mat[3].color)
        {

            if (N_num != 0 && N_num != 6)
            {
                N_instower = Instantiate(Info.Instatnce.I_tower_ob[N_num], gameObject.transform.position,
                    Info.Instatnce.I_tower_ob[N_num].transform.rotation);
                Transform tr = transform;
                N_instower.transform.parent = tr;
                N_num = 0;

            }
            if (N_instower != null)
            {
                gameObject.GetComponent<MeshRenderer>().material = Info.Instatnce.I_node_mat[5];
            }
            else
                return;
        }
        if (gameObject.GetComponent<MeshRenderer>().material.color == Info.Instatnce.I_node_mat[3].color)
        {
            if (N_num == 6)
            {
                N_instower = Instantiate(Info.Instatnce.I_tower_ob[N_num], gameObject.transform.
                    position, Info.Instatnce.I_tower_ob[N_num]. transform.rotation);
                N_num = 0;
            }
            if (N_instower != null)
            {
                gameObject.GetComponent<MeshRenderer>().material = Info.Instatnce.I_node_mat[5];
            }
            else
                return;
        }
        else if (N_num != 0)
        {
            if(gameObject.GetComponent<MeshRenderer>().material.color == Info.Instatnce.I_node_mat[5].color||
                gameObject.GetComponent<MeshRenderer>().material.color == Info.Instatnce.I_node_mat[0].color)
            StartCoroutine(GameSystem.Instatce.ResultText(GameSystem.Instatce.G_fail_text, "건설 불가능한 지역 입니다."));
        }

    }



}

