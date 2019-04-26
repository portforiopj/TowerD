using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(MapManager))]
public class MapEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        MapManager map = target as MapManager;
        map.CreateMap();
    }
  
}
