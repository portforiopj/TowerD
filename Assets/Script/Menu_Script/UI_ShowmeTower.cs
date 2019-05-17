using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_ShowmeTower : MonoBehaviour
{
   void OnEnable()
    {

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < transform.GetChild(i).childCount; j++)
            {
                transform.GetChild(i).GetChild(j).GetChild(0).GetComponent<Image>().sprite = Info.Instatnce.I_tower_base[i].GetChildSprite(j);
            }
        }

    }
}
