using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_PP : MonoBehaviour
{
    Transform tr;
    GameObject PP;
    void Start()
    {
        tr = GetComponent<Transform>();
    }
    void OnEnable()
    {


        for (int i = 0; i < UI_MainManager2.Instatce.P_attends.Count; i++)
        {

            UI_MainManager2.Instatce.SendP(UI_MainManager2.Instatce.P_attends[i].resource, UI_MainManager2.Instatce.P_attends[i].value,
                UI_MainManager2.Instatce.P_attends[i].content,
                PP);


        }

    }
}
