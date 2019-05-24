using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Shop : MonoBehaviour
{
    public Text[] ShopText; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ShopText[0].gameObject.activeSelf || ShopText[1].gameObject.activeSelf)
        {
            ShopText[0].text = "(보유 보석 : " + UI_MainManager2.Instatce.UI_Cash.ToString() + " 보석)";
            ShopText[1].text = "(보유 보석 : " + UI_MainManager2.Instatce.UI_Cash.ToString() + " 보석)";
        }
       
    }
}
