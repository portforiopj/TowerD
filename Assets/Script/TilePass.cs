using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePass : MonoBehaviour
{
    public Transform[] T_tile_tr;

    public Transform Get_T_tile_tr(int count)
    {
        return T_tile_tr[count];
    }
    void Start()
    {
       
    }

   
}
