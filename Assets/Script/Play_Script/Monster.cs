using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public ParticleSystem M_Particle;
    public int M_num;
    public string M_name;
    public int M_hp;
    int M_mhp;
    public int M_dmg;
    public int M_Tadmg;
    public float M_movs;
    public bool[] M_buff=new bool[2];
    public int M_gold;
    public int M_ammor;
    float time;
    int M_choiceint;
    public enum MonsterType
    {
        Red,
        Blue,
        Green
    }
    public MonsterType M_monsterType;
    public Sprite M_sprite;
    public TilePass M_tilePass;
    Transform tr;
     GameObject M_player;
    GameObject[] M_Towers;
    int M_count = 0;
    void Awake()
    {
        M_choiceint = PlayerPrefs.GetInt("Character");
       M_tilePass = GameObject.Find("TilePass").GetComponent<TilePass>();
        M_player = GameObject.Find("Player");
         tr = GetComponent<Transform>();
        tr.position = new Vector3(tr.position.x, tr.position.y + 0.5f, tr.position.z);
    }
   void Start()
    {
        M_hp += GameSystem.Instatce.G_Stage + 1 * (GameSystem.Instatce.G_round + GameSystem.Instatce.G_wave);
        M_mhp = M_hp;
        if(M_monsterType == MonsterType.Red)
        {
            M_Tadmg = M_dmg+ (GameSystem.Instatce.G_Stage + 1 * (GameSystem.Instatce.G_round + GameSystem.Instatce.G_wave));
        }
        if(M_monsterType == MonsterType.Blue)
        {
            M_ammor = 5+(GameSystem.Instatce.G_Stage + 1 * (GameSystem.Instatce.G_round + GameSystem.Instatce.G_wave));
        }
    }
    void Update()
    {
        M_Towers = GameObject.FindGameObjectsWithTag("Tower");
        Move();
        if (M_hp <= 0)
        {
            DieMonster();
        }
        if(M_monsterType == MonsterType.Green)
        {
            time += Time.deltaTime;
            if (time < 1.5f)
            {
                if (M_mhp > M_hp)
                {
                    M_hp += 2+(GameSystem.Instatce.G_Stage + 1 * (GameSystem.Instatce.G_round + GameSystem.Instatce.G_wave));
                    time = 0;
                }
            }
        }
    }
    void DieMonster()
    {
        for(int i=0; i < M_Towers.Length; i++)
        {
            M_Towers[i].GetComponent<Tower>().T_attackmonsterdie = true;
        }
        int rand = Random.Range(0, 3); 
        GameSystem.Instatce.G_gold[rand] += M_gold; 
        Destroy(gameObject);
    }
    void DieMonster2()
    {
        for (int i = 0; i < M_Towers.Length; i++)
        {
            M_Towers[i].GetComponent<Tower>().T_attackmonsterdie = true;
        }
        Destroy(gameObject);
    }
    void OnMouseDown()
    {
        if (Player.P_skill[0] == true)
        {
            Instantiate(M_Particle.gameObject, transform.position, Quaternion.identity);
            M_Particle.Play();
            M_hp -= 50;
            for (int j = 0; j < GameSystem.Instatce.G_gold.Length; j++)
            {
                GameSystem.Instatce.G_gold[j] -= M_player.transform.GetChild(M_choiceint).GetComponent<Player>().P_skill_use_coast[j];
            }
            Player.P_skill[0] = false;
        }
        
    }
    void Move() // 길찾기 함수
    {

        transform.position = Vector3.MoveTowards(tr.position, M_tilePass.Get_T_tilelist_tr(M_count).position + new Vector3(0f, 0.5f, 0f)
        , Time.deltaTime * M_movs);
        tr.LookAt(M_tilePass.Get_T_tilelist_tr(M_count).position + new Vector3(0f, 0.5f, 0f));
        if (Vector3.Distance(transform.position, M_tilePass.Get_T_tilelist_tr(M_count).position + new Vector3(0f, 0.5f, 0f)) < 0.2)
        {
            M_count++;
            if (M_count == M_tilePass.T_tile_list_list[GameSystem.Instatce.G_round].GetCountOfIndex())
            {
                Player.P_hp -= M_dmg+M_Tadmg;
                DieMonster2();
            }
        }
    }




}
