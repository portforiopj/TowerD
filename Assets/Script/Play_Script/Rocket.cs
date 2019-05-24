using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public ParticleSystem R_breakmonster;
    [SerializeField]
    Tower R_tower;
    void Start()
    {
        R_tower = gameObject.GetComponent<Tower>();

      
    }
    public void ShootParticle()
    {
      
        if (gameObject.layer != 16)
        {
            if (R_tower.T_monster != null)
            {
                GameObject a = Instantiate(R_breakmonster.gameObject, R_tower.T_monster.transform.position, Quaternion.identity);
            }
          
       
          
        }
       else
        {

            
      
            for(int i=0; i<R_tower.T_monsters.Count;i++)
            {

                GameObject a = Instantiate(R_breakmonster.gameObject);
                a.transform.parent = R_tower.T_monsters[i].transform;
                a.transform.localPosition = Vector3.zero;
            }   
            
           
         
        }
    }
    // Update is called once per frame
    void Update()
    {
     
    }
}
