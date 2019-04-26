using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public MonsterDatabase M_database;
    public Monster M_monster;
    public TilePass M_tilePass;

    Transform tr;
    
    int M_count = 0;
    void Awake()
    {
        M_tilePass = GameObject.Find("TilePass").GetComponent<TilePass>();
        for(int i=0; i < M_database.MonstersList.Count; i++) // Num 값으로 자기 정보값을 데이터 베이스에서 가져옴
        {
            if(M_database.MonstersList[i].M_num == M_monster.M_num)
            {
                M_monster = M_database.MonstersList[i];
            }
        }

        tr = GetComponent<Transform>();
        tr.position = new Vector3(tr.position.x, tr.position.y +0.5f, tr.position.z);
    }
 
    void Update()
    {
        Move();

    }
    void Die()
    {
        GameSystem.Instatce.G_gold[(int)M_monster.M_monsterType] += M_monster.M_gold; // 타입에 맞춰서 골드 획득
        Destroy(gameObject);
    }
    void Move() // 길찾기 함수
    {

        transform.position = Vector3.MoveTowards(tr.position, M_tilePass.Get_T_tile_tr(M_count).position +new Vector3(0f,0.5f,0f)
        , Time.deltaTime * M_monster.M_movs);
        if (Vector3.Distance(transform.position, M_tilePass.Get_T_tile_tr(M_count).position + new Vector3(0f, 0.5f, 0f)) < 0.2)
        {
            M_count++;         
            if (M_count == M_tilePass.T_tile_tr.Length)
            {
                Player.P_hp -= M_monster.M_dmg*2;
                Die();
            }
        }
    }

}
