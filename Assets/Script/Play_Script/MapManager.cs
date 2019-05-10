using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Transform M_Tiletr;
    public Vector2 M_MapSize_vec;

    [Range(0, 1)]
    public float M_Outline;

    void Start()
    {
        CreateMap();
    }
    public void CreateMap()
    {
        string M_Mapname = "First Map";
        if (transform.Find(M_Mapname))
        {
            DestroyImmediate(transform.Find(M_Mapname).gameObject);
        }
        Transform M_Mapholdertr = new GameObject(M_Mapname).transform;
        M_Mapholdertr.parent = transform;
        for(int x = 0; x < M_MapSize_vec.x; x++)
        {
            for(int y = 0; y < M_MapSize_vec.y; y++)
            {
                Vector3 tilePosition = new Vector3(-M_MapSize_vec.x / 2 + .5f + x, 0, -M_MapSize_vec.y / 2 + .5f + y);
                Transform NewTile = Instantiate(M_Tiletr, tilePosition, Quaternion.Euler(Vector3.right * 90)) as Transform;
                NewTile.localScale = Vector3.one * (1 - M_Outline);
                NewTile.parent = M_Mapholdertr;
                    

                
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
