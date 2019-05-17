using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowText : MonoBehaviour
{

    void OnEnable()
    {
        Debug.Log(transform.childCount);
        UI_MainManager2.Instatce.UI_failtext = gameObject.transform.GetChild(transform.childCount - 1).GetComponent<Text>();
    }
}
