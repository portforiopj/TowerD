using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public ParticleSystem R_breakmonster;
    Tower R_tower;
    bool R_shoot = false;
    void Start()
    {
        R_tower = gameObject.GetComponent<Tower>();
    }
    IEnumerator ShootParticle()
    {
        R_shoot = true;
        GameObject a = Instantiate(R_breakmonster.gameObject, R_tower.T_monster.transform.position, Quaternion.identity);   
        yield return new WaitForSeconds(R_tower.T_Ats);
        R_shoot = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!R_shoot&&R_tower.T_monster !=null)
        {
            StartCoroutine(ShootParticle());
        }
    }
}
