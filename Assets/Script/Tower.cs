using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int T_hp=5;
    public int T_maxhp;
    public string T_name;
    public int T_dmg;
    public float T_Dmr; // 사정거리
    public float T_Ats;// 공격속도
    public bool[] T_buffs = new bool[5];
    bool Testdmg = false;
    public enum TowerState
    {
        Idle,
        Attack,
        Die
    }
    public int T_type;
    void Start()
    {
        
    }
    public void DieTower()
    {
       gameObject.transform.parent.GetComponent<MeshRenderer>()
            .material = Info.Instatnce.I_node_mat[2];
        Debug.Log(gameObject.transform.GetComponentInParent<MeshRenderer>()
            .material.color);
        Destroy(gameObject);
    }
    IEnumerator AttackTower()
    {
        Testdmg = true;
        while (T_hp > 0)
        {
            T_hp -= 2;
            yield return new WaitForSeconds(1.0f);
        }
    }

    void Update()
    {
        if (!Testdmg)
        {
            StartCoroutine(AttackTower());
        }
        if (T_hp <= 0)
        {
            DieTower();
        }
    }
}
