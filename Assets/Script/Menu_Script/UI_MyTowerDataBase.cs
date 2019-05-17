using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CreateAssetMenu(menuName = "Menu/MyTowerDataBase")]
public class UI_MyTowerDataBase : ScriptableObject {
    [SerializeField]
    public List<TowerBase> MyTowerList = new List<TowerBase>();
}
