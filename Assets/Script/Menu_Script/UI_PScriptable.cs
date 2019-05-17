using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CreateAssetMenu(menuName = "Menu/Post")]
public class UI_PScriptable : ScriptableObject
{
    [SerializeField]
    public List<Attend> PostList = new List<Attend>();    
    
}
