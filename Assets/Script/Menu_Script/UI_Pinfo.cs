using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Pinfo : MonoBehaviour
{
    public Attend attend;
    public int P_info_int;
    public int P_info_val;
    public Image P_info_image;
    public Sprite[] P_info_sprites;
    public Text[] P_info_text;
    
    void OnDisable()
    {
        Destroy(gameObject);
    }
    public void ShowInfo()
    {
        for(int i = 0; i < P_info_sprites.Length; i++)
        {
            if (P_info_int == i)
            {
                P_info_image.sprite = P_info_sprites[i];
                break;
            }
            
        }
        P_info_text[0].text = P_info_val.ToString();
    }
    void Start()
    {
        attend.resource = P_info_int;
        attend.value = P_info_val;
        attend.content = P_info_text[1].text;
        ShowInfo();
    }
    public void TakeInfo()
    {
        if (P_info_int == 0)
        {
            UI_MainManager2.Instatce.UI_Gold += P_info_val;
        }
        if (P_info_int == 1)
        {
            UI_MainManager2.Instatce.UI_PlayGold += P_info_val;
        }
        if (P_info_int == 2)
        {
            UI_MainManager2.Instatce.UI_Cash += P_info_val;
        }
        for(int i = 0; i < UI_MainManager2.Instatce.p_Psciprtable.P_PostList.Count; i++)
        {
            if(UI_MainManager2.Instatce.p_Psciprtable.P_PostList[i].resource == P_info_int&&
                UI_MainManager2.Instatce.p_Psciprtable.P_PostList[i].value==P_info_val&&
                UI_MainManager2.Instatce.p_Psciprtable.P_PostList[i].content == P_info_text[1].text)
            {
                UI_MainManager2.Instatce.p_Psciprtable.P_PostList.RemoveAt(i);
                break;
            }
        }
        UI_MainManager2.Instatce.SetAttend();
       Destroy(gameObject);
    }
}
