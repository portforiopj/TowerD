using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Testlist
{
    [SerializeField]
    List<Transform>T_tilepasstr_list= new List<Transform>();

    public Transform GetList(int index)
    {
        return T_tilepasstr_list[index];
    }
}
public class TilePass : MonoBehaviour
{
    public List<Testlist> T_tile_list_list = new List<Testlist>();
    public Transform[] T_tile_tr;
    public Transform Get_T_tile_tr(int count)
    {
        return T_tile_tr[count];
    }

    public Transform Get_T_tilelist_tr(int count)
    {
        return  T_tile_list_list[GameSystem.Instatce.G_round].GetList(count) ;
    }
    void Start()
    {
       

    }

   
}
