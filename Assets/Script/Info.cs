using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject[] I_tower_ob=new GameObject[7];
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
    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
