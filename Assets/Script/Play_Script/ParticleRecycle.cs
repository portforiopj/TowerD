using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRecycle : MonoBehaviour
{
    public Transform tr;
    public Transform target;
    void OnEnable()
    {
        if(tr != null)
        {
            transform.position = new Vector3(tr.position.x, tr.position.y, tr.position.z);
        }
        
    }
    public void MoveTarget()
    {
       transform.position=Vector3.MoveTowards(transform.position, tr.position, Time.deltaTime * 5.0f);
    }
    void Update()
    {
        if (gameObject.GetComponent<ParticleSystem>().IsAlive())
        {

            if (tr == null)
            {
                gameObject.SetActive(false);

            }
            else MoveTarget();
            
        }
        if (!gameObject.GetComponent<ParticleSystem>().IsAlive())
        {
            gameObject.SetActive(false);
        }
      
    }

}
    