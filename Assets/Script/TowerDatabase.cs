using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CreateAssetMenu(menuName = "Tower/Create TowerDatabase Instance")]
public class TowerDatabase : ScriptableObject
{
    [SerializeField]
    public List<Tower> TowersList = new List<Tower>();

    public TowerDatabase() { }
    // Start is called before the first frame update
    public Tower GetMonsterNum(int num)
    {
        for (int i = 0; i < TowersList.Count; i++)
        {
            if (TowersList[i].T_num == num)
                return TowersList[i].GetCopy();
        }
        return null;
    }
    public Tower GetMonsterName(string name)
    {
        for (int i = 0; i < TowersList.Count; i++)
        {
            if (TowersList[i].T_name.ToLower().Equals(name.ToLower()))
                return TowersList[i].GetCopy();
        }
        return null;
    }




}
