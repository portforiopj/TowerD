using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
   
    public GameObject M_map_ob;
    public Transform M_gen_tr;

    public GameObject[] M_monster_ob ; // 몬스터 종류

    public void StartRound() // 유닛 생성
    {
        GameSystem.Instatce.G_playing = true;
        GameSystem.Instatce.G_count++;
        for (int k=0; k < M_map_ob.transform.GetChild(0).childCount; k++) // 생성 위치 찾기
        {
            Color a = M_map_ob.transform.GetChild(0).transform.GetChild(k).GetComponent<MeshRenderer>().material.color;

            if (a == Info.Instatnce.I_node_mat[4].color)
            {

                M_gen_tr.position = new Vector3(M_map_ob.transform.GetChild(0).transform.GetChild(k).transform.position.x, 0.5f,
                    M_map_ob.transform.GetChild(0).transform.GetChild(k).transform.position.z);
            }
        }
       Instantiate(M_monster_ob[GameSystem.Instatce.G_wave], M_gen_tr.position,Quaternion.identity);
       
 
    }
    void Awake() 
    {
    
      
    }
    void Start()
    {
      
        

    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
}
