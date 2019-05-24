using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TakeAll : MonoBehaviour
{
    public GameObject TakePanel;

    public void TakeAllPresent()
    {
        if (TakePanel.transform.childCount != 0)
        {
            for (int i = 0; i < TakePanel.transform.childCount; i++)
            {
                TakePanel.transform.GetChild(i).GetComponent<UI_Pinfo>().TakeInfo();
            }
        }
        else StartCoroutine(UI_MainManager2.Instatce.ResultText(UI_MainManager2.Instatce.UI_failtext, "받을 우편물이 없습니다."));
    }
}
