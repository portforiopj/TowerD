using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowText : MonoBehaviour
{

    void OnEnable()
    {
        for(int i=0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.name == "Resulttext")
            {
                UI_MainManager2.Instatce.UI_failtext = transform.GetChild(i).GetComponent<Text>();
                break;
            }
        }
        

        
    }
}
