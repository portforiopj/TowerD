using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAnimation : MonoBehaviour
{
    public Tower T_tower;
    public TowerDatabase T_database;
    public int T_type;
    Transform T_tr;
    public enum TowerState
    {
        Idle,
        Attack,
        Die
    }
    Animator T_anim;
    public TowerState T_state;
    bool T_Attacking = false;
    public GameObject[] T_monsters2;
    void Awake()
    {
     
        for (int i = 0; i < T_database.TowersList.Count; i++) // Num 값으로 자기 정보값을 데이터 베이스에서 가져옴
        {
            if (T_database.TowersList[i].T_num == T_tower.T_num)
            {
                T_tower = T_database.TowersList[i];
            }
        }

        T_tr = GetComponent<Transform>();
        T_tr.position = new Vector3(T_tr.position.x, T_tr.position.y + 0.5f, T_tr.position.z);
    }
    void TowerPlayState(TowerState state) // 게임 상태 
    {

        switch (state)
        {

            case TowerState.Idle:
                T_anim.SetInteger("T_state", (int)TowerState.Idle);
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
    public IEnumerator AttackTower()
    {

        T_Attacking = true;

        int num = 0;
        float distance;
        GameObject a;

        distance = T_tower.T_Dmr;
        if (T_monsters2.Length > 0)
        {
            float d = 0;
            for (int j = 0; j < T_monsters2.Length; j++)
            {
                d =Mathf.Abs(Vector3.Distance(T_monsters2[j].transform.position, T_tr.position));
                if (d < distance)
                {
                   
                    a = T_monsters2[num];
                    T_monsters2[num] = T_monsters2[j];
                    T_monsters2[j] = T_monsters2[num];
                    num++;
                }

            }
            if (num != 0)
            {
                Debug.Log(T_monsters2[num].GetComponent<MonsterMove>().M_monster.M_hp);
                T_monsters2[num].GetComponent<MonsterMove>().M_monster.M_hp -= T_tower.T_dmg;
                T_state = TowerState.Idle;
                yield return new WaitForSeconds(T_tower.T_Ats);
            }
        }
        T_Attacking = false;
    }



    void Update()
    {
        T_monsters2 = GameObject.FindGameObjectsWithTag("Monster");
        TowerPlayState(T_state);

        if (T_monsters2.Length > 0)
        {

            T_state = TowerState.Attack;
            
        }
        else T_state = TowerState.Idle;

        if (T_tower.T_hp <= 0)
        {
            T_state = TowerState.Die;
        }

    }
    void Start()
    {
        T_anim = GetComponent<Animator>();
        T_tr = GetComponent<Transform>();
    }
   

    // Update is called once per frame
   
}
