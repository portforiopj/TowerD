using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    Animator P_anim;
    public string P_name;
    
    public static int P_hp = 50;
    public bool[] P_buff = new bool[2];
    public enum PlayerState
    {
        Idle ,
        Skill ,
        Die
    }
    public PlayerState P_state;
    
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
                P_anim.SetInteger("P_state",(int)PlayerState.Idle);
                break;
            case PlayerState.Skill:
                P_anim.SetInteger("P_state", (int)PlayerState.Skill);
                break;
            case PlayerState.Die:
                P_anim.SetInteger("P_state", (int)PlayerState.Die);
                break;
            
        }
    }
    void Start()
    {
        P_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
