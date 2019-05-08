using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tower : MonoBehaviour
{

    GameObject T_head;
    ParticleSystem[] T_particle;
    public ParticleSystem T_breaktower;
    public static bool T_attackmonsterdie = true;
    public int T_num;
    public int T_hp;
    public int T_maxhp;
    public string T_name;
    public int T_dmg;
    public float T_Dmr; // 사정거리
    public float T_Ats;// 공격속도
    public bool[] T_buffs;
    public int[] T_buygold;
    public bool T_rangecheck = false;
    public Image T_uiimage;
    public GameObject T_rangesprite;
    public GameObject[] T_Towers;
    GameObject T_monster = null;
    public enum Towertype
    {
        EMP,
        Gun,
        Roccet,
        Energy,
        Super
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

    void TowerCheckRange(bool Check)
    {
        T_rangesprite.gameObject.SetActive(Check);

    }
    void AttackParticle()
    {
        for (int i = 0; i < T_particle.Length; i++)
        {
            T_particle[i].Play();
        }
    }
    void Awake()
    {
        T_anim = GetComponent<Animator>();
        T_tr = GetComponent<Transform>();
        T_tr.position = new Vector3(T_tr.position.x, T_tr.position.y + 0.5f, T_tr.position.z);
        T_rangesprite.transform.localScale = new Vector3(T_Dmr * 9.6f, T_Dmr * 9.6f, 1f);
        T_particle = gameObject.GetComponentsInChildren<ParticleSystem>();
       
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
                T_anim.Play("Toweridle");
                break;
            case TowerState.Attack:
                T_anim.Play("TowerAttack");
                break;
            case TowerState.Die:
                T_anim.Play("TowerDie");
                break;

        }
    }
    void OnButtenCheck(bool check)
    {
        T_Towers = GameObject.FindGameObjectsWithTag("Tower");
        if (!check)
        {
            for (int i = 0; i < T_Towers.Length; i++)
            {
                T_Towers[i].GetComponent<Tower>().T_rangecheck = false;
            }
        }
        T_rangecheck = !check;
        GameObject a = GameObject.Find("Canvas");
        if (a.transform.GetChild(6).GetChild(0).gameObject.activeSelf || a.transform.GetChild(5).GetChild(2).gameObject.activeSelf)
        {
            a.transform.GetChild(6).GetChild(0).gameObject.SetActive(check);
            a.transform.GetChild(6).GetChild(2).gameObject.SetActive(!check);

        }
        if (a.transform.GetChild(6).GetChild(1).gameObject.activeSelf)
        {
            a.transform.GetChild(6).GetChild(1).gameObject.SetActive(check);
            a.transform.GetChild(6).GetChild(2).gameObject.SetActive(!check);
        }
        a.transform.GetChild(6).GetComponent<UI_Control>().UI_tower_info = gameObject.GetComponent<Tower>();
    }
    void OnMouseDown()
    {
        OnButtenCheck(T_rangecheck);

    }
    public void IDleTower()
    {

        if (T_monsters2.Length > 0)
        {

            T_state = TowerState.Attack;
        }

    }
    public void DieTower()
    {
        if (gameObject.transform.parent.name == "Special")
        {
            gameObject.transform.parent.parent.GetComponent<MeshRenderer>()
            .material = Info.Instatnce.I_node_mat[3];
            T_breaktower.Play();
            Destroy(gameObject);
        }
        else
        {
            gameObject.transform.parent.parent.GetComponent<MeshRenderer>()
           .material = Info.Instatnce.I_node_mat[2];
            T_breaktower.Play();
            //Destroy(gameObject);
        }
    }
    IEnumerator AttackTower()
    {
        T_Attacking = true;
        float distance;        
        distance = T_Dmr;
        if(T_monster == null)
        {
            T_attackmonsterdie = true;
        }
        if (T_monsters2.Length > 0)
        {
            float d = 0;

            for (int j = 0; j < T_monsters2.Length; j++)
            {

                if (T_monsters2.Length == 0)
                {
                    break;
                }
                if (T_monsters2[j] == null)
                {
                    break;
                }
                else d = Mathf.Abs(Vector3.Distance(T_monsters2[j].transform.position, T_tr.position));
                if (d < distance)
                {
                    if (T_attackmonsterdie)
                    {
                        T_monster = T_monsters2[j];
                        T_attackmonsterdie = false;
                    }
                }
            }
            if (T_monster != null)
            {
                if (T_monster.GetComponent<Monster>().M_hp < T_dmg)
                {
                    T_attackmonsterdie = true;
                }
                T_monster.GetComponent<Monster>().M_hp -= T_dmg;
                if (T_monster != null)
                {
                    T_hp -= T_monster.GetComponent<Monster>().M_dmg;
                }
                if (CheckHead())
                {
                    T_head.transform.LookAt(new Vector3(T_monster.transform.position.x, T_head.transform.position.y, T_monster.transform.position.z));
                }
                AttackParticle();
                if (T_hp <= 0)
                {
                    T_state = TowerState.Die;
                }
                yield return new WaitForSeconds(T_Ats);         
            }           
            T_state = TowerState.Idle;
            T_Attacking = false;
        }
    }
    void CheckHead2()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.tag == "Head")
            {
                T_head = transform.GetChild(i).gameObject;
                break;
            }
        }
    }
    bool CheckHead()
    {
        CheckHead2();
        if (T_head == null)
        {
            return false;
        }
        else return true;
    }
    public void TowerAnimationAttack()
    {

        if (!T_Attacking)
        {
            StartCoroutine(AttackTower());
        }
    }


    void Update()
    {

        T_uiimage.fillAmount = (float)T_hp / T_maxhp;
        TowerPlayState(T_state);
        T_monsters2 = GameObject.FindGameObjectsWithTag("Monster");

        TowerCheckRange(T_rangecheck);



    }


}