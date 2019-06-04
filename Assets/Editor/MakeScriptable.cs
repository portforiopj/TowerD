using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class MakeScriptable 
{
    [MenuItem("Assets/Create/MyScriptableObject")]
    public static void CreateMyAsset()
    {
        UI_P_Psciprtable asset = ScriptableObject.CreateInstance<UI_P_Psciprtable>();

        AssetDatabase.CreateAsset(asset, "Assets/Post.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

}
public class MakeScriptable2
{
    [MenuItem("Assets/Create/MyScriptableObject2")]
    public static void CreateMyAsset()
    {
        UI_MyTowerDataBase asset = ScriptableObject.CreateInstance<UI_MyTowerDataBase>();

        AssetDatabase.CreateAsset(asset, "Assets/Tower.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
