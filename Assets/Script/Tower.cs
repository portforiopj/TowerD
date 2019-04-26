using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    Animator T_anim;
    public int T_hp = 5;
    public int T_maxhp;
    public string T_name;
    public int T_dmg;
    public float T_Dmr; // 사정거리
    public float T_Ats;// 공격속도
    public bool[] T_buffs = new bool[5];
    bool T_Attacking = false;
    public GameObject[] T_monster = new GameObject[20];
    public enum TowerState
    {
        Idle,
        Attack,
        Die
    }
    public TowerState T_state;
    public int T_type;
    void Start()
    {
        T_anim = GetComponent<Animator>();
    }
    void TowerPlayState(TowerState state) // 게임 상태 
    {

        switch (state)
        {

            case TowerState.Idle:
                T_anim.SetInteger("T_state",(int)TowerState.Idle);
                break;
            case TowerState.Attack:
                T_anim.SetInteger("T_state", (int)TowerState.Attack);
                break;
            case TowerState.Die:
                T_anim.SetInteger("T_state", (int)TowerState.Die);
                break;

        }
    }
    public void DieTower()
    {
        gameObject.transform.parent.GetComponent<MeshRenderer>()
             .material = Info.Instatnce.I_node_mat[2];
        Debug.Log(gameObject.transform.GetComponentInParent<MeshRenderer>()
            .material.color);
        Destroy(gameObject);
    }
    void AttackTower()
    {
        T_Attacking = true;
        Transform tr;
        GameObject[] monsters;
        GameObject game;
        monsters = GameObject.FindGameObjectsWithTag("Monster");
        int num = 0;
        float distance;
        float distance2;
        tr = GetComponent<Transform>();
        distance = T_Dmr;
        if (monsters.Length > 0)
        {
            float d = 0;
            for (int j = 0; j < monsters.Length; j++)
            {
                d = Vector3.Distance(monsters[j].transform.position, tr.position);
                if (d < distance)
                {
                    monsters[num] = monsters[j];
                    num++;
                }
            }
            for (int j = 0; j < num; j++)
            {
                distance2 = Vector3.Distance(T_monster[0].transform.position, tr.position);
                float dis = Vector3.Distance(T_monster[j].transform.position, tr.position);
                if (dis < distance2)
                {
                    game = T_monster[0];
                    T_monster[0] = T_monster[j];
                    T_monster[j] = game;
                }
            }
            for (int j = 0; j < num; j++)
            {
                if (T_monster[j].GetComponent<Monster>().M_hp > 0)
                {
                    T_monster[j].GetComponent<Monster>().M_hp -= T_dmg;
                    break;
                }
            }
        }
    }

    

    void Update()
    {
        TowerPlayState(T_state);
    }
}
