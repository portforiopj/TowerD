using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRoatation : MonoBehaviour
{
    Camera C_camera;
    // Start is called before the first frame update
    void Start()
    {
        C_camera = GameObject.Find("Main Camera").GetComponent<Camera>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(new Vector3(gameObject.transform.position.x, C_camera.transform.position.y, gameObject.transform.position.z));
        

    }
}
