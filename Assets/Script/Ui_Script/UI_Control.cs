using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Control : MonoBehaviour
{
    Player UI_player_info;
    public GameObject UI_control_pannal;
    public Tower UI_tower_info;
    
    // Start is called before the first frame update
    void Awake()
    {
        UI_player_info = GameObject.Find("Player").GetComponent<Player>();
        UIState();
    }
    void UIState()
    {
        if (UI_control_pannal.transform.GetChild(0).gameObject.activeSelf)
        {
            UI_control_pannal.transform.GetChild(0).GetChild(0).GetComponent<UI_ControlButton>().Red = UI_player_info.P_skill_use_coast[0];
            UI_control_pannal.transform.GetChild(0).GetChild(0).GetComponent<UI_ControlButton>().Blue = UI_player_info.P_skill_use_coast[1];
            UI_control_pannal.transform.GetChild(0).GetChild(0).GetComponent<UI_ControlButton>().Green = UI_player_info.P_skill_use_coast[2];
            UI_control_pannal.transform.GetChild(0).GetChild(1).GetComponent<UI_ControlButton>().Red = UI_player_info.P_skill_use_coast[0];
            UI_control_pannal.transform.GetChild(0).GetChild(1).GetComponent<UI_ControlButton>().Blue = UI_player_info.P_skill_use_coast[1];
            UI_control_pannal.transform.GetChild(0).GetChild(1).GetComponent<UI_ControlButton>().Green = UI_player_info.P_skill_use_coast[2];
        }
        if (UI_control_pannal.transform.GetChild(1).gameObject.activeSelf)
        {
            UI_control_pannal.transform.GetChild(1).GetChild(0).GetComponent<UI_ControlButton>().Red = Info.Instatnce.I_tower_ob[1].GetComponent<Tower>().T_buygold[0];
            UI_control_pannal.transform.GetChild(1).GetChild(0).GetComponent<UI_ControlButton>().Blue = Info.Instatnce.I_tower_ob[1].GetComponent<Tower>().T_buygold[1];
            UI_control_pannal.transform.GetChild(1).GetChild(0).GetComponent<UI_ControlButton>().Green = Info.Instatnce.I_tower_ob[1].GetComponent<Tower>().T_buygold[2];
            UI_control_pannal.transform.GetChild(1).GetChild(1).GetComponent<UI_ControlButton>().Red = Info.Instatnce.I_tower_ob[2].GetComponent<Tower>().T_buygold[0];
            UI_control_pannal.transform.GetChild(1).GetChild(1).GetComponent<UI_ControlButton>().Blue = Info.Instatnce.I_tower_ob[2].GetComponent<Tower>().T_buygold[1];
            UI_control_pannal.transform.GetChild(1).GetChild(1).GetComponent<UI_ControlButton>().Green = Info.Instatnce.I_tower_ob[2].GetComponent<Tower>().T_buygold[2];
            UI_control_pannal.transform.GetChild(1).GetChild(2).GetComponent<UI_ControlButton>().Red = Info.Instatnce.I_tower_ob[3].GetComponent<Tower>().T_buygold[0];
            UI_control_pannal.transform.GetChild(1).GetChild(2).GetComponent<UI_ControlButton>().Blue = Info.Instatnce.I_tower_ob[3].GetComponent<Tower>().T_buygold[1];
            UI_control_pannal.transform.GetChild(1).GetChild(2).GetComponent<UI_ControlButton>().Green = Info.Instatnce.I_tower_ob[3].GetComponent<Tower>().T_buygold[2];
        }
        if (UI_control_pannal.transform.GetChild(2).gameObject.activeSelf)
        {
            if(UI_tower_info.T_num == 1)
            {
             
                UI_control_pannal.transform.GetChild(2).GetChild(0).GetComponent<UI_ControlButton>().Red = Info.Instatnce.I_tower_ob[4].GetComponent<Tower>().T_buygold[0];
                UI_control_pannal.transform.GetChild(2).GetChild(0).GetComponent<UI_ControlButton>().Blue = Info.Instatnce.I_tower_ob[4].GetComponent<Tower>().T_buygold[1];
                UI_control_pannal.transform.GetChild(2).GetChild(0).GetComponent<UI_ControlButton>().Green = Info.Instatnce.I_tower_ob[4].GetComponent<Tower>().T_buygold[2];
                UI_control_pannal.transform.GetChild(2).GetChild(1).GetComponent<UI_ControlButton>().Red = Info.Instatnce.I_tower_ob[5].GetComponent<Tower>().T_buygold[0];
                UI_control_pannal.transform.GetChild(2).GetChild(1).GetComponent<UI_ControlButton>().Blue = Info.Instatnce.I_tower_ob[5].GetComponent<Tower>().T_buygold[1];
                UI_control_pannal.transform.GetChild(2).GetChild(1).GetComponent<UI_ControlButton>().Green = Info.Instatnce.I_tower_ob[5].GetComponent<Tower>().T_buygold[2];
            }
            if (UI_tower_info.T_num == 2)
            {
                UI_control_pannal.transform.GetChild(2).GetChild(0).GetComponent<UI_ControlButton>().Red = Info.Instatnce.I_tower_ob[4].GetComponent<Tower>().T_buygold[0];
                UI_control_pannal.transform.GetChild(2).GetChild(0).GetComponent<UI_ControlButton>().Blue = Info.Instatnce.I_tower_ob[4].GetComponent<Tower>().T_buygold[1];
                UI_control_pannal.transform.GetChild(2).GetChild(0).GetComponent<UI_ControlButton>().Green = Info.Instatnce.I_tower_ob[4].GetComponent<Tower>().T_buygold[2];
                UI_control_pannal.transform.GetChild(2).GetChild(1).GetComponent<UI_ControlButton>().Red = Info.Instatnce.I_tower_ob[6].GetComponent<Tower>().T_buygold[0];
                UI_control_pannal.transform.GetChild(2).GetChild(1).GetComponent<UI_ControlButton>().Blue = Info.Instatnce.I_tower_ob[6].GetComponent<Tower>().T_buygold[1];
                UI_control_pannal.transform.GetChild(2).GetChild(1).GetComponent<UI_ControlButton>().Green = Info.Instatnce.I_tower_ob[6].GetComponent<Tower>().T_buygold[2];
            }
            if (UI_tower_info.T_num == 3)
            {
                
                UI_control_pannal.transform.GetChild(2).GetChild(0).GetComponent<UI_ControlButton>().Red = Info.Instatnce.I_tower_ob[5].GetComponent<Tower>().T_buygold[0];
                UI_control_pannal.transform.GetChild(2).GetChild(0).GetComponent<UI_ControlButton>().Blue = Info.Instatnce.I_tower_ob[5].GetComponent<Tower>().T_buygold[1];
                UI_control_pannal.transform.GetChild(2).GetChild(0).GetComponent<UI_ControlButton>().Green = Info.Instatnce.I_tower_ob[5].GetComponent<Tower>().T_buygold[2];
                UI_control_pannal.transform.GetChild(2).GetChild(1).GetComponent<UI_ControlButton>().Red = Info.Instatnce.I_tower_ob[6].GetComponent<Tower>().T_buygold[0];
                UI_control_pannal.transform.GetChild(2).GetChild(1).GetComponent<UI_ControlButton>().Blue = Info.Instatnce.I_tower_ob[6].GetComponent<Tower>().T_buygold[1];
                UI_control_pannal.transform.GetChild(2).GetChild(1).GetComponent<UI_ControlButton>().Green = Info.Instatnce.I_tower_ob[6].GetComponent<Tower>().T_buygold[2];
            }
        }
    }
    public void UpGradeTower(int i)
    {
        bool Notenough = false;
        
        if (UI_tower_info.T_num == 1)
        {

            if (i == 0)
            {
                for (int j = 0; j < GameSystem.Instatce.G_gold.Length; j++)
                {
                    if (GameSystem.Instatce.G_gold[j] < Info.Instatnce.I_tower_ob[4].GetComponent<Tower>().T_buygold[j])
                    {
                        Notenough = true;
                        StartCoroutine(GameSystem.Instatce.ResultText(GameSystem.Instatce.G_fail_text, "골드가 부족합니다"));
                        break;
                    }
                }
                if (!Notenough)
                {
                    GameObject a = Instantiate(Info.Instatnce.I_tower_ob[4], new Vector3(UI_tower_info.transform.parent.position.x,
                    UI_tower_info.transform.parent.position.y + 0.5f, UI_tower_info.transform.parent.position.z), Quaternion.identity);
                    a.transform.parent = UI_tower_info.transform.parent;
                    for (int j = 0; j < GameSystem.Instatce.G_gold.Length; j++)
                    {
                        GameSystem.Instatce.G_gold[j] -= Info.Instatnce.I_tower_ob[4].GetComponent<Tower>().T_buygold[j];

                    }
                    Destroy(UI_tower_info.gameObject);
                }
            }
            if (i == 1)
            {
                for (int j = 0; j < GameSystem.Instatce.G_gold.Length; j++)
                {
                    if (GameSystem.Instatce.G_gold[j] < Info.Instatnce.I_tower_ob[5].GetComponent<Tower>().T_buygold[j])
                    {
                        Notenough = true;
                        StartCoroutine(GameSystem.Instatce.ResultText(GameSystem.Instatce.G_fail_text, "골드가 부족합니다"));
                        break;
                    }
                }
                if (!Notenough)
                {
                    GameObject a = Instantiate(Info.Instatnce.I_tower_ob[5], new Vector3(UI_tower_info.transform.parent.position.x,
                    UI_tower_info.transform.parent.position.y + 0.5f, UI_tower_info.transform.parent.position.z), Quaternion.identity);
                    a.transform.parent = UI_tower_info.transform.parent;
                    for (int j = 0; j < GameSystem.Instatce.G_gold.Length; j++)
                    {
                        GameSystem.Instatce.G_gold[j] -= Info.Instatnce.I_tower_ob[4].GetComponent<Tower>().T_buygold[j];

                    }
                    Destroy(UI_tower_info.gameObject);
                }
            }


        }
        if (UI_tower_info.T_num == 2)
        {
            if (i == 0)
            {
                for (int j = 0; j < GameSystem.Instatce.G_gold.Length; j++)
                {
                    if (GameSystem.Instatce.G_gold[j] < Info.Instatnce.I_tower_ob[4].GetComponent<Tower>().T_buygold[j])
                    {
                        Notenough = true;
                        StartCoroutine(GameSystem.Instatce.ResultText(GameSystem.Instatce.G_fail_text, "골드가 부족합니다"));
                        break;
                    }
                }
                if (!Notenough)
                {
                    GameObject a = Instantiate(Info.Instatnce.I_tower_ob[4], new Vector3(UI_tower_info.transform.parent.position.x,
                    UI_tower_info.transform.parent.position.y + 0.5f, UI_tower_info.transform.parent.position.z), Quaternion.identity);
                    a.transform.parent = UI_tower_info.transform.parent;
                    for (int j = 0; j < GameSystem.Instatce.G_gold.Length; j++)
                    {
                        GameSystem.Instatce.G_gold[j] -= Info.Instatnce.I_tower_ob[4].GetComponent<Tower>().T_buygold[j];

                    }
                    Destroy(UI_tower_info.gameObject);

                }
            }
            if (i == 1)
            {
                for (int j = 0; j < GameSystem.Instatce.G_gold.Length; j++)
                {
                    if (GameSystem.Instatce.G_gold[j] < Info.Instatnce.I_tower_ob[6].GetComponent<Tower>().T_buygold[j])
                    {
                        Notenough = true;
                        StartCoroutine(GameSystem.Instatce.ResultText(GameSystem.Instatce.G_fail_text, "골드가 부족합니다"));
                        break;
                    }
                }
                if (!Notenough)
                {
                    GameObject a = Instantiate(Info.Instatnce.I_tower_ob[6], new Vector3(UI_tower_info.transform.parent.position.x,
                    UI_tower_info.transform.parent.position.y + 0.5f, UI_tower_info.transform.parent.position.z), Quaternion.identity);
                    a.transform.parent = UI_tower_info.transform.parent;
                    for (int j = 0; j < GameSystem.Instatce.G_gold.Length; j++)
                    {
                        GameSystem.Instatce.G_gold[j] -= Info.Instatnce.I_tower_ob[6].GetComponent<Tower>().T_buygold[j];

                    }
                    Destroy(UI_tower_info.gameObject);

                }
            }
        }

        if (UI_tower_info.T_num == 3)
        {
            if (i == 0)
            {
                for (int j = 0; j < GameSystem.Instatce.G_gold.Length; j++)
                {
                    if (GameSystem.Instatce.G_gold[j] < Info.Instatnce.I_tower_ob[5].GetComponent<Tower>().T_buygold[j])
                    {
                        Notenough = true;
                        StartCoroutine(GameSystem.Instatce.ResultText(GameSystem.Instatce.G_fail_text, "골드가 부족합니다"));
                        break;
                    }
                }
                if (!Notenough)
                {
                    GameObject a = Instantiate(Info.Instatnce.I_tower_ob[5], new Vector3(UI_tower_info.transform.parent.position.x,
                    UI_tower_info.transform.parent.position.y + 0.5f, UI_tower_info.transform.parent.position.z), Quaternion.identity);
                    a.transform.parent = UI_tower_info.transform.parent;
                    for (int j = 0; j < GameSystem.Instatce.G_gold.Length; j++)
                    {
                        GameSystem.Instatce.G_gold[j] -= Info.Instatnce.I_tower_ob[5].GetComponent<Tower>().T_buygold[j];

                    }
                    Destroy(UI_tower_info.gameObject);

                }
                if (i == 1)
                {

                    for (int j = 0; j < GameSystem.Instatce.G_gold.Length; j++)
                    {
                        if (GameSystem.Instatce.G_gold[j] < Info.Instatnce.I_tower_ob[6].GetComponent<Tower>().T_buygold[j])
                        {
                            Notenough = true;
                            StartCoroutine(GameSystem.Instatce.ResultText(GameSystem.Instatce.G_fail_text, "골드가 부족합니다"));
                            break;
                        }
                    }
                    if (!Notenough)
                    {
                        GameObject a = Instantiate(Info.Instatnce.I_tower_ob[6], new Vector3(UI_tower_info.transform.parent.position.x,
                        UI_tower_info.transform.parent.position.y + 0.5f, UI_tower_info.transform.parent.position.z), Quaternion.identity);
                        a.transform.parent = UI_tower_info.transform.parent;
                        for (int j = 0; j < GameSystem.Instatce.G_gold.Length; j++)
                        {
                            GameSystem.Instatce.G_gold[j] -= Info.Instatnce.I_tower_ob[6].GetComponent<Tower>().T_buygold[j];

                        }
                        Destroy(UI_tower_info.gameObject);

                    }
                }
            }

        }
    }
    
    public void BuildTower(int i)
    {
        Node.N_num = 0;
        bool Notenough = false;
        for (int j = 0; j < Info.Instatnce.I_tower_ob[i].GetComponent<Tower>().T_buygold.Length; j++)
        {
            if (Info.Instatnce.I_tower_ob[i].GetComponent
             <Tower>().T_buygold[j] > GameSystem.Instatce.G_gold[j])
           {
               Notenough = true;
                StartCoroutine(GameSystem.Instatce.ResultText(GameSystem.Instatce.G_fail_text, "골드가 부족합니다"));
                break;
            }

        }
        if (!Notenough) {
            Node.N_num = i;
        }
        
       
    }
    public void ActSkill(int i)
    {
        bool Notenough = false;
        for(int j = 0; j < GameSystem.Instatce.G_gold.Length; j++)
        {
            if(GameSystem.Instatce.G_gold[i] < UI_player_info.P_skill_use_coast[i])
            {
                Notenough = true;
                StartCoroutine(GameSystem.Instatce.ResultText(GameSystem.Instatce.G_fail_text, "골드가 부족합니다"));
                break;
            }
        }
        if (!Notenough)
        {
            for (int j = 0; j < GameSystem.Instatce.G_gold.Length; j++)
            {
                GameSystem.Instatce.G_gold[i] -= UI_player_info.P_skill_use_coast[i];
            }

            Player.P_skill[i] = true;
            UI_player_info.P_state = Player.PlayerState.Skill;
        }
      
    }
    public void BuildButton()
    {
        UI_control_pannal.transform.GetChild(0).gameObject.SetActive(false);
        UI_control_pannal.transform.GetChild(1).gameObject.SetActive(true);
    }
    public void CancelButton(int i)
    {


        UI_control_pannal.transform.GetChild(0).gameObject.SetActive(true);

        UI_control_pannal.transform.GetChild(i).gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        UIState();
        
    }
}
