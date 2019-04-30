﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public Image T_uiimage;

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
       
        
       
    }
    void Start()
    {
        T_maxhp = T_hp;
    }
    void TowerPlayState(TowerState state) // 게임 상태 
    {

        switch (state)
        {

            case TowerState.Idle:
                T_anim.Play("TowerIdle");
                break;
            case TowerState.Attack:
                T_anim.Play("TowerAttack");
                break;
            case TowerState.Die:
                T_anim.Play("TowerDie");
                break;

        }
    }
    void OnMouseDown()
    {
        GameObject a = GameObject.Find("Canvas");
        
        if (a.transform.GetChild(5).GetChild(0).gameObject.activeSelf)
        {
            a.transform.GetChild(5).GetChild(0).gameObject.SetActive(false);
            a.transform.GetChild(5).GetChild(2).gameObject.SetActive(true);
            
        }
        if (a.transform.GetChild(5).GetChild(1).gameObject.activeSelf)
        {
            a.transform.GetChild(5).GetChild(1).gameObject.SetActive(false);
            a.transform.GetChild(5).GetChild(2).gameObject.SetActive(true);
        }
        a.transform.GetChild(5).GetComponent<UI_Control>().UI_tower_info = gameObject.GetComponent<Tower>();
    }
    public void IDleTower()
    {

        if (T_monsters2.Length > 0)
        {

            T_state = TowerState.Attack;
        }
        if (T_hp <= 0)
        {
            T_state = TowerState.Die;
        }
    }
    public void DieTower()
    {
        if (gameObject.transform.parent.name == "Special")
        {
            gameObject.transform.parent.GetComponent<MeshRenderer>()
            .material = Info.Instatnce.I_node_mat[3];
            Destroy(gameObject);
        }
        else
        {
            gameObject.transform.parent.GetComponent<MeshRenderer>()
           .material = Info.Instatnce.I_node_mat[2];


            Destroy(gameObject);
        }
    }
   IEnumerator AttackTower()
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
                if(T_monsters2.Length == 0)
                {
                    break;
                }               
                if(T_monsters2[j] == null)
                {
                    break;
                }
                else d = Mathf.Abs(Vector3.Distance(T_monsters2[j].transform.position, T_tr.position));
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
          
                T_monsters2[num-1].GetComponent<Monster>().M_hp -= T_dmg;
                if(T_monsters2[num - 1]!= null) {
                    T_hp -= T_monsters2[num - 1].GetComponent<Monster>().M_dmg;
                }                
                yield return new WaitForSeconds(T_Ats);
                T_state = TowerState.Idle;
            }
        }
        T_state = TowerState.Idle;
        T_Attacking = false;
    }
    public void TowerAnimationAttack()
    {
        if (T_hp <= 0)
        {
            T_state = TowerState.Die;
        }
        if (!T_Attacking)
        {
            StartCoroutine(AttackTower());
        }
    }


    void Update()
    {
        Debug.Log((float)T_hp / T_maxhp);
        T_uiimage.fillAmount = (float)T_hp / T_maxhp;
        TowerPlayState(T_state);
        T_monsters2 = GameObject.FindGameObjectsWithTag("Monster");
     
       
        

    }
}

