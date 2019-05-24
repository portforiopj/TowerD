using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UI_TowerManager : MonoBehaviour
{
    public Image[] UI_image;
    public Image[] UI_image_Player;
    public Image[] UI_image_public;
    public Image[] UI_Player_sprites;
    public Image UI_Player_sprite;
    Player[] UI_player;
    bool TowerP = false;
    bool TChange = false;
    int Towerc = 0;
    int TowerCount = 0;
    int TowerCount2 = 0;
    // Start is called before the first frame update
    public void ShowImage()
    {
        for(int i= 0; i < UI_image_Player.Length; i++)
        {
            UI_image_Player[i].enabled = false;
        }
 
        UI_Player_sprite.sprite = UI_player[TowerCount2].P_sprite;
        if (TowerCount2 == 0)
        {
            for (int i = 0; i < Info.Instatnce.I_tower_Mecha.Length; i++)
            {
                UI_image[i].sprite = Info.Instatnce.I_tower_Mecha[i].transform.GetChild(0).GetComponent<Tower>().T_sprite;
            }
        }
        if (TowerCount2 == 1)
        {
            for (int i = 0; i < Info.Instatnce.I_tower_Elemental.Length; i++)
            {
                
                UI_image[i].sprite = Info.Instatnce.I_tower_Elemental[i].transform.GetChild(0).GetComponent<Tower>().T_sprite;
            }
        }
        if (TowerCount2 == 2)
        {
            for (int i = 0; i < Info.Instatnce.I_tower_Humen.Length; i++)
            {
                UI_image[i].sprite = Info.Instatnce.I_tower_Humen[i].transform.GetChild(0).GetComponent<Tower>().T_sprite;
            }
        }
        for (int i = 0; i < Info.Instatnce.I_tower_public.Length; i++)
        {
            UI_image_public[i].sprite = Info.Instatnce.I_tower_public[i].GetComponent<Tower>().T_sprite;
        }   
        for (int i = 0; i < Info.Instatnce.I_tower_base[TowerCount2].GetCountOfIndex(); i++)
        {
           
            if (Info.Instatnce.I_tower_base[TowerCount2].GetList(i) != null)
            {
                UI_image_Player[i].enabled=true;
                UI_image_Player[i].sprite = Info.Instatnce.I_tower_base[TowerCount2].GetChildSprite(i);
            }         
        }
    }
   
    public void ChoiceCharacter(int i)
    {
        TowerCount2 = i;
        ShowImage();


    }

    public void PositionSet(int i)
    {
        TowerCount = i;
        if (TChange)
        {
            if (TowerP)
            {
                if (TowerCount >= 3)
                {
                    ChoicepublicTower(Towerc, TowerCount);
                    TowerP = false;
                    TChange = false;
                    ShowImage();
                    return;
                }
                else StartCoroutine(UI_MainManager2.Instatce.ResultText(UI_MainManager2.Instatce.UI_failtext, "지정 불가능한 종류입니다"));

            }

            if (TowerCount2 == 0)
            {
                if (TowerCount < 3)
                {
                    ChoiceMechaTower(Towerc, TowerCount);
                }
                else StartCoroutine(UI_MainManager2.Instatce.ResultText(UI_MainManager2.Instatce.UI_failtext, "지정 불가능한 종류입니다"));
            }
            if (TowerCount2 == 1)
            {
                if (TowerCount < 3)
                {
                    ChoiceElementalTower(Towerc, TowerCount);
                }
                else StartCoroutine(UI_MainManager2.Instatce.ResultText(UI_MainManager2.Instatce.UI_failtext, "지정 불가능한 종류입니다"));
            }
            if (TowerCount2 == 2)
            {
                if (TowerCount < 3)
                {
                    ChoiceHumenTower(Towerc, TowerCount);
                }
                else StartCoroutine(UI_MainManager2.Instatce.ResultText(UI_MainManager2.Instatce.UI_failtext, "지정 불가능한 종류입니다"));
            }
        } 
        TChange = false;
        Info.Instatnce.TowerSave();
        ShowImage();
    }

    public void ChoiceChange(int i)
    {

        Towerc = i;
        if (gameObject.tag == "Public")
        {
            TowerP = true;
        }
        TChange = true;
    }

    public void ChoiceMechaTower(int i, int j)
    {

        Info.Instatnce.MyTowerBase.MyTowerList[TowerCount2].SetList(j, Info.Instatnce.I_tower_Mecha[i]);

    }


    public void ChoiceElementalTower(int i, int j)
    {
        Info.Instatnce.MyTowerBase.MyTowerList[TowerCount2].SetList(j, Info.Instatnce.I_tower_Elemental[i]);

    }
    public void ChoiceHumenTower(int i, int j)
    {
        Info.Instatnce.MyTowerBase.MyTowerList[TowerCount2].SetList(j, Info.Instatnce.I_tower_Humen[i]);

    }
    public void ChoicepublicTower(int i, int j)
    {
        Info.Instatnce.MyTowerBase.MyTowerList[TowerCount2].SetList(j, Info.Instatnce.I_tower_public[i]);

    }
    void Start()
    {
        UI_player = GameObject.Find("Player").GetComponentsInChildren<Player>();
        for (int i = 0; i < UI_Player_sprites.Length; i++)
        {
            UI_Player_sprites[i].sprite = UI_player[i].P_sprite;
        }
       
       

    }


}
