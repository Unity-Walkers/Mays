using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SenceChangeManager))]
public class SceneCahngeManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        SenceChangeManager obj = target as SenceChangeManager;
        obj.DebugMode= EditorGUILayout.Toggle("DebugMode", obj.DebugMode);
        obj.fadeColor = EditorGUILayout.ColorField("Color", obj.fadeColor);
        obj.Scene = EditorGUILayout.TextField("Next Scene", obj.Scene);
        obj.ChangerTime = EditorGUILayout.Slider("Change Time", obj.ChangerTime, 0.0F, 10.0F);

        EditorUtility.SetDirty(target);


    }
}