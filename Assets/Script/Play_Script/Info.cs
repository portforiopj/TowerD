using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TowerBase
{
    [SerializeField]
    List<GameObject> T_texture_prb = new List<GameObject>();

    public GameObject GetList(int index)
    {
        return T_texture_prb[index];
    }
    public int GetCountOfIndex()
    {
        return T_texture_prb.Count;
    }
   
    public GameObject SetList(int index,GameObject game)
    {
        T_texture_prb[index] = game;
        return T_texture_prb[index];
    }
    public Sprite GetChildSprite(int i)
    {
        return T_texture_prb[i].transform.GetChild(0).GetComponent<Tower>().T_sprite;
    }
    
}

//타워 정보 싱글톤
public class Info : MonoBehaviour
{
    static Info instance;

    public static Info Instatnce
    {
        get
        {
            return instance;
        }
    }
    public UI_MyTowerDataBase MyTowerBase;
    public GameObject[] I_tower_Mecha;
    public GameObject[] I_tower_Elemental;
    public GameObject[] I_tower_Humen;
    public GameObject[] I_tower_public;
    public TowerBase[] I_tower_base;
    public Material[] I_node_mat = new Material[6];
    // 0.몬스터 이동경로 1.플레이어 위치 2. 타워 건설 O 
    //3. 특수 타워 건설 O 4.몬스터 시작위치 5.타워 건설 X
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        TowerSave();
    }
    public void TowerSave()
    {
        for(int i = 0; i < MyTowerBase.MyTowerList.Count; i++)
        {
            for(int j = 0; j < MyTowerBase.MyTowerList[i].GetCountOfIndex(); j++)
            {
                I_tower_base[i].SetList(j, MyTowerBase.MyTowerList[i].GetList(j));
            }
        }
     }

        
}
