using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ControlButton : MonoBehaviour
{

    // 끄고 킬 게임 오브젝트들
    public GameObject Redimage;
    public GameObject Greenimage;
    public GameObject Blueimage;
    //정보값 받아와서 출력할 text
    public Text Redtext;    
    public Text Greentext;    
    public Text Bluetext;


    //test용 정보값
    public int Red;
    public int Blue;
    public int Green;
    // Start is called before the first frame update
    void Start()
    {
        SetCostImage();
    }

    // Update is called once per frame
    void Update()
    {
        SetCostImage();
    }

    void SetCostImage()
    {
        

        //값이 0인 자원은 안보이게 처리
        if(Red == 0)
        {
            Redimage.SetActive(false);
        }
        if(Blue == 0)
        {
            Blueimage.SetActive(false);
        }
        if (Green == 0)
        {
            Greenimage.SetActive(false);
        }

        //
        Redtext.text = Red.ToString();
        Greentext.text = Green.ToString();
        Bluetext.text = Blue.ToString();


    }

}
