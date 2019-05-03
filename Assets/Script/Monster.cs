using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int M_num;
    public string M_name;
    public int M_hp;
    public int M_dmg;
    public float M_movs;
    public bool[] M_buff=new bool[2];
    public int M_gold;
    public enum MonsterType
    {
        Red,
        Blue,
        Green
    }
    public MonsterType M_monsterType;
    public Sprite M_sprite;
    public TilePass M_tilePass;
    Transform tr;

    int M_count = 0;
    void Awake()
    {
        M_tilePass = GameObject.Find("TilePass").GetComponent<TilePass>();
       
        tr = GetComponent<Transform>();
        tr.position = new Vector3(tr.position.x, tr.position.y + 0.5f, tr.position.z);
    }

    void Update()
    {
        Move();
        if (M_hp <= 0)
        {
            DieMonster();
        }
    }
    void DieMonster()
    {
        GameSystem.Instatce.G_gold[(int)M_monsterType] += M_gold; // 타입에 맞춰서 골드 획득
        Destroy(gameObject);
    }
    void DieMonster2()
    {
        Destroy(gameObject);
    }
    void OnMouseDown()
    {
        if (Player.P_skill[0] == true)
        {
            M_hp -= 50;
            Player.P_skill[0] = false;
        }
        if (Player.P_skill[1] == true)
        {
            Player.P_skill[1] = false;
        }
    }
    void Move() // 길찾기 함수
    {

        transform.position = Vector3.MoveTowards(tr.position, M_tilePass.Get_T_tilelist_tr(M_count).position + new Vector3(0f, 0.5f, 0f)
        , Time.deltaTime * M_movs);
        if (Vector3.Distance(transform.position, M_tilePass.Get_T_tilelist_tr(M_count).position + new Vector3(0f, 0.5f, 0f)) < 0.2)
        {
            M_count++;
            if (M_count == M_tilePass.T_tile_list_list[GameSystem.Instatce.G_round].GetCountOfIndex())
            {
                Player.P_hp -= M_dmg * 2;
                DieMonster2();
            }
        }
    }




}
