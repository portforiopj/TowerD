using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CreateAssetMenu(menuName = "Menu/P_Post")]
public class UI_P_Psciprtable : ScriptableObject
{
    [SerializeField]
    public List<Attend>P_PostList = new List<Attend>();    
}
