using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PartcleList
{
    [SerializeField]
    List<ParticleSystem> particlelist = new List<ParticleSystem>();

    public ParticleSystem GetList(int index)
    {
        return particlelist[index];
    }
    public int GetCountOfIndex()
    {
        return particlelist.Count;
    }
    public void AddParticle(ParticleSystem particle)
    {
        particlelist.Add(particle);
    }
}
public class ParticleManager : MonoBehaviour
{
    public ParticleSystem[] AttackParticle = new ParticleSystem[10];
    
    public List<PartcleList> particles = new List<PartcleList>();
    


    void Awake()
    {

        for (int i = 0; i < AttackParticle.Length; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GameObject a = Instantiate(AttackParticle[i].gameObject);
                particles[i].AddParticle(a.GetComponent<ParticleSystem>());
                a.SetActive(false);
            }

        }
    }
    public void AutoParticleSet(int i,Transform target)
    {
        for (int j = 0; j < particles[i].GetCountOfIndex(); j++)
        {
            if (!particles[i].GetList(j).gameObject.activeSelf)
            {
                particles[i].GetList(j).GetComponent<ParticleRecycle>().tr = target;
                particles[i].GetList(j).gameObject.SetActive(true);
                break;
                
            }
        }
    }
    public void ParticleSet(GameObject game,Transform target)
    {
        int num = 0;
        int m = 0;
        for(int i = 0; i < AttackParticle.Length; i++)
        {
           if(game.GetComponent<Rocket>().R_breakmonster == AttackParticle[i])
            {
                m = i;
                break;
            }
        }
        for(int j=0; j < particles[m].GetCountOfIndex(); j++)
        {
            if (!particles[m].GetList(j).gameObject.activeSelf)
            {
                particles[m].GetList(j).GetComponent<ParticleRecycle>().tr = target;
                particles[m].GetList(j).gameObject.SetActive(true);
                particles[m].GetList(j).GetComponent<ParticleRecycle>().MoveTarget();
                break;
            }
            else num++;
            if(num == particles[m].GetCountOfIndex())
            {
                GameObject a = Instantiate(AttackParticle[m].gameObject);
                particles[m].AddParticle(a.GetComponent<ParticleSystem>());
                a.SetActive(false);
            }
        }
    }

}
