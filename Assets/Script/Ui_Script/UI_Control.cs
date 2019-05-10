using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Control : MonoBehaviour
{
    Player UI_player_info;
    public GameObject UI_control_pannal;
    public Tower UI_tower_info;
    public UI_MainManger C_uimain;
    int UI_UpgradeCount = 0;
    int UI_UpgradeCount2 = 0;
    public GameObject[] UI_Start;
    int UI_Choiceint;
    // Start is called before the first frame update
    void Start()
    {

        UI_Choiceint = PlayerPrefs.GetInt("Character");
       UI_player_info = GameObject.Find("Player").transform.GetChild(UI_Choiceint).GetComponent<Player>();
        UI_Start[2].GetComponent<Text>().text = "Round " + (GameSystem.Instatce.G_round+1).ToString();
        UIState();

    }
    public void Startbutton()
    {
        for(int i=0; i < UI_Start.Length; i++)
        {
            UI_Start[i].gameObject.SetActive(false);
        }
       
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
            UI_control_pannal.transform.GetChild(1).GetChild(0).GetComponent<UI_ControlButton>().Red = Info.Instatnce.I_tower_base[GameSystem.Instatce.G_choiceint].GetList(0).transform.GetChild(0).GetComponent<Tower>().T_buygold[0];
            UI_control_pannal.transform.GetChild(1).GetChild(0).GetComponent<UI_ControlButton>().Blue = Info.Instatnce.I_tower_base[GameSystem.Instatce.G_choiceint].GetList(0).transform.GetChild(0).GetComponent<Tower>().T_buygold[1];
            UI_control_pannal.transform.GetChild(1).GetChild(0).GetComponent<UI_ControlButton>().Green = Info.Instatnce.I_tower_base[GameSystem.Instatce.G_choiceint].GetList(0).transform.GetChild(0).GetComponent<Tower>().T_buygold[2];
            UI_control_pannal.transform.GetChild(1).GetChild(1).GetComponent<UI_ControlButton>().Red = Info.Instatnce.I_tower_base[GameSystem.Instatce.G_choiceint].GetList(1).transform.GetChild(0).GetComponent<Tower>().T_buygold[0];
            UI_control_pannal.transform.GetChild(1).GetChild(1).GetComponent<UI_ControlButton>().Blue = Info.Instatnce.I_tower_base[GameSystem.Instatce.G_choiceint].GetList(1).transform.GetChild(0).GetComponent<Tower>().T_buygold[1];
            UI_control_pannal.transform.GetChild(1).GetChild(1).GetComponent<UI_ControlButton>().Green = Info.Instatnce.I_tower_base[GameSystem.Instatce.G_choiceint].GetList(1).transform.GetChild(0).GetComponent<Tower>().T_buygold[2];
            UI_control_pannal.transform.GetChild(1).GetChild(2).GetComponent<UI_ControlButton>().Red = Info.Instatnce.I_tower_base[GameSystem.Instatce.G_choiceint].GetList(2).transform.GetChild(0).GetComponent<Tower>().T_buygold[0];
            UI_control_pannal.transform.GetChild(1).GetChild(2).GetComponent<UI_ControlButton>().Blue = Info.Instatnce.I_tower_base[GameSystem.Instatce.G_choiceint].GetList(2).transform.GetChild(0).GetComponent<Tower>().T_buygold[1];
            UI_control_pannal.transform.GetChild(1).GetChild(2).GetComponent<UI_ControlButton>().Green = Info.Instatnce.I_tower_base[GameSystem.Instatce.G_choiceint].GetList(2).transform.GetChild(0   ).GetComponent<Tower>().T_buygold[2];
        }
        if (UI_control_pannal.transform.GetChild(2).gameObject.activeSelf)
        {
            UpGradeTowerState();
        }
    }
    void UpGradeTowerState()
    {
        if (UI_tower_info != null)
        {
            if (UI_tower_info.transform.parent.GetChild(0).gameObject.activeSelf)
            {

                UI_control_pannal.transform.GetChild(2).GetChild(0).GetComponent<UI_ControlButton>().Red = UI_tower_info.transform.parent.GetChild(1).GetComponent<Tower>().T_buygold[0];
                UI_control_pannal.transform.GetChild(2).GetChild(0).GetComponent<UI_ControlButton>().Blue = UI_tower_info.transform.parent.GetChild(1).GetComponent<Tower>().T_buygold[1];
                UI_control_pannal.transform.GetChild(2).GetChild(0).GetComponent<UI_ControlButton>().Green = UI_tower_info.transform.parent.GetChild(1).GetComponent<Tower>().T_buygold[2];
                UI_control_pannal.transform.GetChild(2).GetChild(1).GetComponent<UI_ControlButton>().Red = UI_tower_info.transform.parent.GetChild(3).GetComponent<Tower>().T_buygold[0];
                UI_control_pannal.transform.GetChild(2).GetChild(1).GetComponent<UI_ControlButton>().Blue = UI_tower_info.transform.parent.GetChild(3).GetComponent<Tower>().T_buygold[1];
                UI_control_pannal.transform.GetChild(2).GetChild(1).GetComponent<UI_ControlButton>().Green = UI_tower_info.transform.parent.GetChild(3).GetComponent<Tower>().T_buygold[2];
                UI_UpgradeCount = 1;
                UI_UpgradeCount2 = 3;
            }
            else if (UI_tower_info.transform.parent.GetChild(1).gameObject.activeSelf)
            {
                UI_control_pannal.transform.GetChild(2).GetChild(0).GetComponent<UI_ControlButton>().Red = UI_tower_info.transform.parent.GetChild(2).GetComponent<Tower>().T_buygold[0];
                UI_control_pannal.transform.GetChild(2).GetChild(0).GetComponent<UI_ControlButton>().Blue = UI_tower_info.transform.parent.GetChild(2).GetComponent<Tower>().T_buygold[1];
                UI_control_pannal.transform.GetChild(2).GetChild(0).GetComponent<UI_ControlButton>().Green = UI_tower_info.transform.parent.GetChild(2).GetComponent<Tower>().T_buygold[2];
                UI_control_pannal.transform.GetChild(2).GetChild(1).GetComponent<UI_ControlButton>().Red = UI_tower_info.transform.parent.GetChild(4).GetComponent<Tower>().T_buygold[0];
                UI_control_pannal.transform.GetChild(2).GetChild(1).GetComponent<UI_ControlButton>().Blue = UI_tower_info.transform.parent.GetChild(4).GetComponent<Tower>().T_buygold[1];
                UI_control_pannal.transform.GetChild(2).GetChild(1).GetComponent<UI_ControlButton>().Green = UI_tower_info.transform.parent.GetChild(4).GetComponent<Tower>().T_buygold[2];
                UI_UpgradeCount = 2;
                UI_UpgradeCount2 = 4;
            }
            else if (UI_tower_info.transform.parent.GetChild(3).gameObject.activeSelf)
            {
                UI_control_pannal.transform.GetChild(2).GetChild(0).GetComponent<UI_ControlButton>().Red = UI_tower_info.transform.parent.GetChild(2).GetComponent<Tower>().T_buygold[0];
                UI_control_pannal.transform.GetChild(2).GetChild(0).GetComponent<UI_ControlButton>().Blue = UI_tower_info.transform.parent.GetChild(2).GetComponent<Tower>().T_buygold[1];
                UI_control_pannal.transform.GetChild(2).GetChild(0).GetComponent<UI_ControlButton>().Green = UI_tower_info.transform.parent.GetChild(2).GetComponent<Tower>().T_buygold[2];
                UI_control_pannal.transform.GetChild(2).GetChild(1).GetComponent<UI_ControlButton>().Red = UI_tower_info.transform.parent.GetChild(4).GetComponent<Tower>().T_buygold[0];
                UI_control_pannal.transform.GetChild(2).GetChild(1).GetComponent<UI_ControlButton>().Blue = UI_tower_info.transform.parent.GetChild(4).GetComponent<Tower>().T_buygold[1];
                UI_control_pannal.transform.GetChild(2).GetChild(1).GetComponent<UI_ControlButton>().Green = UI_tower_info.transform.parent.GetChild(4).GetComponent<Tower>().T_buygold[2];
                UI_UpgradeCount = 2;
                UI_UpgradeCount2 = 4;
            }
            else if (UI_tower_info.transform.parent.GetChild(4).gameObject.activeSelf || UI_tower_info.transform.parent.GetChild(2).gameObject.activeSelf)
            {
                UI_control_pannal.transform.GetChild(0).gameObject.SetActive(true);
                UI_control_pannal.transform.GetChild(2).gameObject.SetActive(false);
                StartCoroutine(GameSystem.Instatce.ResultText(C_uimain.UI_fail_text, "타워가 최종 업그레이드 상태입니다."));
            }
        }
        else
        {
            CancelButton(2);
        }
       
    }
    public void UpGradeTower(int i)
    {
        GameObject[] T_Towers = GameObject.FindGameObjectsWithTag("Tower");
        if (T_Towers.Length != 0)
        {
            for (int j = 0; j < T_Towers.Length; j++)
            {
                T_Towers[j].GetComponent<Tower>().T_rangecheck = false;
            }
        }
        bool Notenough = false;
        if (i == 0)
        {
            for (int j = 1; j < UI_tower_info.transform.parent.childCount; j++)
            {

                if (UI_UpgradeCount == j)
                {
                  
                    for (int k = 0; k < GameSystem.Instatce.G_gold.Length; k++)
                    {
                       

                        if (GameSystem.Instatce.G_gold[k] < UI_tower_info.transform.parent.GetChild(UI_UpgradeCount).GetComponent<Tower>().T_buygold[k])
                        {
                            Notenough = true;
                            StartCoroutine(GameSystem.Instatce.ResultText(C_uimain.UI_fail_text, "골드가 부족합니다."));
                            break;
                        }
                    }
                    if (!Notenough)
                    {
                        for (int k = 0; k < GameSystem.Instatce.G_gold.Length; k++)
                        {
                            GameSystem.Instatce.G_gold[k] -= UI_tower_info.transform.parent.GetChild(UI_UpgradeCount).GetComponent<Tower>().T_buygold[k];
                        }
                        UI_tower_info.transform.parent.GetChild(UI_UpgradeCount).gameObject.SetActive(true);
                        UI_tower_info.gameObject.SetActive(false);
                   }
                    break;
                }
            }
            UI_tower_info = null;
        }
        if (i == 1)
        {
            for (int j = 1; j < UI_tower_info.transform.parent.childCount; j++)
            {

                if (UI_UpgradeCount2 == j)
                {
                    for (int k = 0; k < GameSystem.Instatce.G_gold.Length; k++)
                    {
                        if (GameSystem.Instatce.G_gold[k] < UI_tower_info.transform.parent.GetChild(UI_UpgradeCount2).GetComponent<Tower>().T_buygold[k])
                        {
                            Notenough = true;
                            break;
                        }
                    }
                    if (!Notenough)
                    {
                        for (int k = 0; k < GameSystem.Instatce.G_gold.Length; k++)
                        {
                            GameSystem.Instatce.G_gold[k] -= UI_tower_info.transform.parent.GetChild(UI_UpgradeCount2).GetComponent<Tower>().T_buygold[k];
                        }
                        UI_tower_info.transform.parent.GetChild(UI_UpgradeCount2).gameObject.SetActive(true);
                        UI_tower_info.gameObject.SetActive(false);
                    }

                }
            }
            UI_tower_info = null;
        }

        CancelButton(1);


    }

    public void BuildTower(int i)
    {
        UI_tower_info = null;
        GameObject[] T_Towers = GameObject.FindGameObjectsWithTag("Tower");
        if (T_Towers.Length != 0)
        {
            for (int j = 0; j < T_Towers.Length; j++)
            {
                T_Towers[j].GetComponent<Tower>().T_rangecheck = false;
            }
        }
        Node.N_num = -1;
        bool Notenough = false;
        for (int j = 0; j < Info.Instatnce.I_tower_base[GameSystem.Instatce.G_choiceint].GetList(i).transform.GetChild(0).GetComponent<Tower>().T_buygold.Length; j++)
        {
            if (Info.Instatnce.I_tower_base[GameSystem.Instatce.G_choiceint].GetList(i).transform.GetChild(0).GetComponent
             <Tower>().T_buygold[j] > GameSystem.Instatce.G_gold[j])
           {
               Notenough = true;
                StartCoroutine(GameSystem.Instatce.ResultText(C_uimain.UI_fail_text, "골드가 부족합니다"));
                break;
            }

        }
        if (!Notenough) {
            Node.N_num = i;
        }
        
       
    }
    public void ActSkill(int i)
    {
        GameObject[] T_Towers = GameObject.FindGameObjectsWithTag("Tower");
        if (T_Towers.Length != 0)
        {
            for (int j = 0; j < T_Towers.Length; j++)
            {
                T_Towers[j].GetComponent<Tower>().T_rangecheck = false;
            }
        }
        bool Notenough = false;
        for(int j = 0; j < GameSystem.Instatce.G_gold.Length; j++)
        {
            if(GameSystem.Instatce.G_gold[j] < UI_player_info.P_skill_use_coast[j])
            {
                Notenough = true;
                StartCoroutine(GameSystem.Instatce.ResultText(C_uimain.UI_fail_text, "골드가 부족합니다"));
                break;
            }
        }
        if (!Notenough)
        {
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
        Node.N_num = -1;
        UI_tower_info = null;
    }
    // Update is called once per frame
    void Update()
    {
        UIState();
        
    }
}
