using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Tower
{
    public int T_num;
    public int T_hp;
    public int T_maxhp;
    public string T_name;
    public int T_dmg;
    public float T_Dmr; // 사정거리
    public float T_Ats;// 공격속도
    public bool[] T_buffs ;
    public int[] T_buygold ; 
    public enum Towertype
    {
        Archer,
        Gunner,
        Warrior
    }
    public Towertype T_towertype;

    public Sprite T_sprite;
    public Tower() { }
    public Tower(int num,string name,int hp,int dmg,float dmr,float ats, bool[] buffs,int[] b_gold,Towertype towertype,Sprite sprite)
    {
        T_num = num;
        T_name = name;
        T_hp = hp;
        T_dmg = dmg;
        T_Dmr = dmr;
        T_Ats = ats;
        T_buffs = buffs;
        T_buygold = b_gold;
        T_towertype = towertype;
        T_sprite = sprite;

    }
    public Tower GetCopy()
    {
        return (Tower)base.MemberwiseClone();
    }

}
