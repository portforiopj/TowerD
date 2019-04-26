using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CreateAssetMenu(menuName = "Example/Create MonsterDatabase Instance")]
public class MonsterDatabase : ScriptableObject
{
    [SerializeField]
    public List<Monster> MonstersList = new List<Monster>();

    public MonsterDatabase() { }
    // Start is called before the first frame update
    public Monster GetMonsterNum(int num)
    {
        for (int i = 0; i < MonstersList.Count; i++)
        {
            if (MonstersList[i].M_num ==num)
                return MonstersList[i].getCopy();
        }
        return null;
    }
    public Monster GetMonsterName(string name)
    {
        for (int i = 0; i < MonstersList.Count; i++)
        {
            if (MonstersList[i].M_name.ToLower().Equals(name.ToLower()))
                return MonstersList[i].getCopy();
        }
        return null;
    }
}
