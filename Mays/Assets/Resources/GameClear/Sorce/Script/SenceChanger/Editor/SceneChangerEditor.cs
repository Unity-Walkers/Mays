using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SenceChanger))]
public class SceneChanger : Editor
{
    public override void OnInspectorGUI()
    {
        SenceChanger obj = target as SenceChanger;
        obj.Color = EditorGUILayout.ColorField("Color", obj.Color);
        obj.SceneName = EditorGUILayout.TextField("Next Scene", obj.SceneName);
        obj.Interval = EditorGUILayout.Slider("Change Time", obj.Interval, 0.0F, 10.0F);
        EditorUtility.SetDirty(target);
    }
}