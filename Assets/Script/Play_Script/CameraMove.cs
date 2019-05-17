using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMove : MonoBehaviour {


    public GameObject focusing_bullet;
    private Vector3 dragOrigin;
    private float dragSpeed = 0.5f;
    public GameObject CM_map;
    public bool trace_ball = true;      //player 잡을지 공잡을지 카메라 이동 함수 정해주는 bool값, shoot에서 false만들고 movescript에서 true 만들어 준다.
    public bool focusing_ball = false;  //공따라가는 함수가 공이 벽과 충돌 후에도 투명해진 공을 안따라가도록 focus_something 함수의 실행을 조절해주는 함수.
    float C_xlimit = 0;
    float C_ylimit = 0;
    public int setOnce = 0; //setCameraDefault 한번만 실행 되도록 bool값으로도 해줄수 있지만 그냥 int도 써봤다.

    void Start()
    {
        Invoke("SetMap", 0.5f);
    }
    


    void SetMap()
    {
        CM_map = GameObject.Find("MapFile").gameObject;
        for (int i = 0; i < CM_map.transform.childCount; i++)
        {
            if (CM_map.transform.GetChild(i).gameObject.activeSelf)
            {
                if (CM_map.transform.GetChild(i).tag == "Small")
                {
                    C_xlimit = 3;
                    C_ylimit = 2.5f;
                    break;
                }
                if (CM_map.transform.GetChild(i).tag == "Middle")
                {
                    C_xlimit = 5;
                    C_ylimit = 4.5f;
                    break;
                }
                if (CM_map.transform.GetChild(i).tag == "Big")
                {
                    C_xlimit = 7;
                    C_ylimit = 6.5f;
                    break;
                }
            }
        }
    }

void Update()
    {
        
        movingCam();
    }
	
	

   



    void movingCam()
    {
        //공 쏘는 중에는 카메라 이동 안되게

        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;                     
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        
        Vector3 move = new Vector3(-pos.x * dragSpeed, 0, -pos.y * dragSpeed);



        transform.Translate(move, Space.World);

        if (transform.position.x >C_xlimit)
            transform.position = new Vector3(C_xlimit, this.gameObject.transform.position.y, gameObject.transform.position.z);
        if (transform.position.z > C_ylimit)
            transform.position = new Vector3(this.gameObject.transform.position.x, gameObject.transform.position.y, C_ylimit);
        if (transform.position.x < -C_xlimit)
            transform.position = new Vector3(-C_xlimit, this.gameObject.transform.position.y, gameObject.transform.position.z);
        if (transform.position.z < -C_ylimit)
            transform.position = new Vector3(this.gameObject.transform.position.x, gameObject.transform.position.y, -C_ylimit);
    }


}
