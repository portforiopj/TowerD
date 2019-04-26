using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
   
    public GameObject M_map_ob;
    public MonsterDatabase M_mondata_data;
    public Transform M_gen_tr;

    public GameObject[] M_monster_ob = new GameObject[5]; // 몬스터 종류
    public int M_count = 0;
    public void StartRound() // 유닛 생성
    {
        GameSystem.Instatce.G_playing = false;
        
        for (int k=0; k < M_map_ob.transform.GetChild(0).childCount; k++) // 생성 위치 찾기
        {
            Color a = M_map_ob.transform.GetChild(0).transform.GetChild(k).GetComponent<MeshRenderer>().material.color;

            if (a == Info.Instatnce.I_node_mat[4].color)
            {
                Debug.Log("");
                M_gen_tr.position = new Vector3(M_map_ob.transform.GetChild(0).transform.GetChild(k).transform.position.x, 0.5f,
                    M_map_ob.transform.GetChild(0).transform.GetChild(k).transform.position.z);
            }
        }
       Instantiate(M_monster_ob[GameSystem.Instatce.G_wave], M_gen_tr.position,Quaternion.identity);
        if (M_count < GameSystem.Instatce.G_roundunit[GameSystem.Instatce.G_wave] - 1)
        {
            
            M_count++;
            Invoke("StartRound", GameSystem.Instatce.G_roundgen);
        }
        else M_count = 0;
    }
    void Awake() 
    {
        for(int i=0; i < M_monster_ob.Length; i++) {
            M_monster_ob[i] = M_mondata_data.MonstersList[i].M_prefab_ob;
        }
      
    }
    void Start()
    {
      
        

    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
}
