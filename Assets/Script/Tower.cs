using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int T_num;
    public int T_hp;
    public int T_maxhp;
    public string T_name;
    public int T_dmg;
    public float T_Dmr; // 사정거리
    public float T_Ats;// 공격속도
    public bool[] T_buffs;
    public int[] T_buygold;
    public enum Towertype
    {
        Archer,
        Gunner,
        Warrior
    }
    public Towertype T_towertype;
    public Sprite T_sprite;
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
        T_anim = GetComponent<Animator>();
        T_tr = GetComponent<Transform>();
        T_tr.position = new Vector3(T_tr.position.x, T_tr.position.y + 0.5f, T_tr.position.z);
        

        for(int i=0;i< Info.Instatnce.I_tower_ob.Length; i++)
        {
          
        }
       
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
    public void IDleTower()
    {
        T_monsters2 = GameObject.FindGameObjectsWithTag("Monster");
        if (T_monsters2.Length > 0)
        {
           
            T_state = TowerState.Attack;
            Debug.Log(T_state);
        }
        else T_state = TowerState.Idle;

        if (T_hp <= 0)
        {
            T_state = TowerState.Die;
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

        distance = T_Dmr;
        if (T_monsters2.Length > 0)
        {
            float d = 0;
            for (int j = 0; j < T_monsters2.Length; j++)
            {
                d = Mathf.Abs(Vector3.Distance(T_monsters2[j].transform.position, T_tr.position));
                if (d < distance)
                {

                    a = T_monsters2[num];
                    T_monsters2[num] = T_monsters2[j];
                    T_monsters2[j] = a;
                    num++;
                }

            }
            if (num != 0)
            {

                T_monsters2[num].GetComponent<Monster>().M_hp -= T_dmg;
              
                yield return new WaitForSeconds(T_Ats);
                T_state = TowerState.Idle;
            }
        }
        T_Attacking = false;
    }



    void Update()
    {
        
        TowerPlayState(T_state);

       

    }
}

