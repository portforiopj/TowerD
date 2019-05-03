using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    Animator P_anim;
    public string P_name;
    GameObject P_map;
    public static int P_hp = 50;
    public bool[] P_buff = new bool[2];
    public static bool[] P_skill = new bool[2];
    public int[] P_skill_use_coast = new int[3];
    Transform P_tr;
    Transform P_target_tr;
    public enum PlayerState
    {
        Idle ,
        Skill ,
        Die
    }
    public PlayerState P_state;
    
    public void SkillPlayer()
    {
        P_state = PlayerState.Idle;
    }
    public void DiePlayer()
    {
        if (P_hp <= 0)
        {
            P_state = PlayerState.Die;
            GameSystem.Instatce.G_state = GameSystem.GameState.Gameover;
            
        }
    }
   
    void PlayeRoundState(PlayerState state) // 게임 상태 
    {

        switch (state)
        {

            case PlayerState.Idle:
                P_anim.Play("PlayerIdle");
                break;
            case PlayerState.Skill:
                P_anim.Play("PlayerSkill");
                break;
            case PlayerState.Die:
                P_anim.Play("PlayerDie");
                break;
            
        }
    }
    void Start()
    {
        P_anim = GetComponent<Animator>();
        P_map = GameObject.Find("MapFile").transform.GetChild(GameSystem.Instatce.G_round).gameObject;
        for (int i=0; i < P_map.transform.childCount; i++)
        {
            if(P_map.transform.GetChild(i).GetComponent<MeshRenderer>().material.color == Info.Instatnce.I_node_mat[1].color)
            {
                P_target_tr = P_map.transform.GetChild(i);
                Debug.Log(P_map.transform.GetChild(i));
                break;
            }
        }
        P_tr = GetComponent<Transform>();
        P_tr.position = new Vector3( P_target_tr.position.x,P_target_tr.position.y+0.5f,P_target_tr.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
