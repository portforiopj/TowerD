using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour
{
    bool Alphaup=true;
    bool Alphadown=false;
    Color32 Alphadeps;
    int Count;
   void Update()
    {
        if (Count < 15)
        {
            StartCoroutine(TextAlpha());
        }
        else
        {
            UI_MainManager2.Instatce.Tutorial = false;
            PlayerPrefs.SetInt("Tutorial", 1);
            Attend attend;
            attend = new Attend(2, 30, "튜토리얼 보상입니다.");
            UI_MainManager2.Instatce.p_Psciprtable.P_PostList.Add(attend);
            Destroy(gameObject);
        }
    }
    IEnumerator TextAlpha()
    {
        while (Alphaup)
        {
            Alphadeps =gameObject.GetComponent<Image>().color;
            Alphadeps.a++;
            gameObject.GetComponent<Image>().color = Alphadeps;
            if (Alphadeps.a >= 80)
            {
                Alphaup = false;
                Alphadown = true;
                Count++;
            }
            yield return new WaitForSeconds(0.1f);
             
        }
        while (Alphadown)
        {
            Alphadeps = gameObject.GetComponent<Image>().color;
            Alphadeps.a--;
            gameObject.GetComponent<Image>().color = Alphadeps;
            if (Alphadeps.a <= 20)
            {
                Alphaup = true;
                Alphadown = false;
                Count++;
            }
            yield return new WaitForSeconds(0.1f);

        }
    }
}
