using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 타일 노드
public class Node : MonoBehaviour
{
    public Info N_info;

    public GameObject N_instower;
    public static int N_num = -1;
    void Awake()
    {

    }
    void Update()
    {

    }

    void OnMouseDown()// 마우스 입력값을 받아 타워를 설치하고 타일의 마테리얼 변경
    {
        GameObject[] T_Towers = GameObject.FindGameObjectsWithTag("Tower");
        if (T_Towers.Length != 0)
        {
            for (int j = 0; j < T_Towers.Length; j++)
            {
                T_Towers[j].GetComponent<Tower>().T_rangecheck = false;
            }
        }
        
        if (gameObject.GetComponent<MeshRenderer>().material.color == Info.Instatnce.I_node_mat[2].color ||
            gameObject.GetComponent<MeshRenderer>().material.color == Info.Instatnce.I_node_mat[3].color)
        {

            if (N_num != -1 && N_num != 6)// 타워 건설시 돈이 부족하면 취소하고 돈이 있으면 돈이나가고 타워가 건설됨
            {
                bool Notenough = false;
                for (int i = 0; i < Info.Instatnce.I_tower_ob[N_num].transform.GetChild(0).GetComponent<Tower>().T_buygold.Length; i++)
                {
                    if (Info.Instatnce.I_tower_ob[N_num].transform.GetChild(0).GetComponent
                        <Tower>().T_buygold[i] > GameSystem.Instatce.G_gold[i])
                    {
                        Notenough = true;
                    }                         
                }
                if (!Notenough)
                {
                    N_instower = Instantiate(Info.Instatnce.I_tower_ob[N_num], new Vector3(gameObject.transform.
                       position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z),
                       Info.Instatnce.I_tower_ob[N_num].transform.rotation);
                    Transform tr = transform;
                    N_instower.transform.parent = tr;
                   
                    for (int j = 0; j < Info.Instatnce.I_tower_ob[N_num].transform.GetChild(0).GetComponent<Tower>().T_buygold.Length; j++)
                    {
                        GameSystem.Instatce.G_gold[j] -= Info.Instatnce.I_tower_ob[N_num].transform.GetChild(0).GetComponent
                        <Tower>().T_buygold[j];
                    }
                    N_num = 0;
                }
                

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
               
                
                    N_instower = Instantiate(Info.Instatnce.I_tower_ob[N_num], new Vector3(gameObject.transform.
                 position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z)
                 , Info.Instatnce.I_tower_ob[N_num].transform.rotation);
                    
                    for (int j = 0; j < Info.Instatnce.I_tower_ob[N_num].transform.GetChild(0).GetComponent<Tower>().T_buygold.Length; j++)
                    {
                        GameSystem.Instatce.G_gold[j] -= Info.Instatnce.I_tower_ob[N_num].transform.GetChild(0).GetComponent
                        <Tower>().T_buygold[j];
                    }
                    N_num = 0;
                
            }
            if (N_instower != null)
            {
                gameObject.GetComponent<MeshRenderer>().material = Info.Instatnce.I_node_mat[5];
            }
            else
                return;
        }
        else if (N_num != -1)
        {
            if(gameObject.GetComponent<MeshRenderer>().material.color == Info.Instatnce.I_node_mat[5].color||
                gameObject.GetComponent<MeshRenderer>().material.color == Info.Instatnce.I_node_mat[0].color)
            StartCoroutine(GameSystem.Instatce.ResultText(GameSystem.Instatce.G_fail_text, "건설 불가능한 지역 입니다."));
        }

    }



}

