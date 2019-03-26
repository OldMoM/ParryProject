using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Abuffer))]
public class AbufferEditor : Editor
{
    Abuffer buff;

    bool m_AbufferTest;
    SerializedProperty magazine;

    private void OnEnable()
    {
        buff = (Abuffer)target;
        magazine = serializedObject.FindProperty("magazine");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(magazine, new GUIContent("枪膛"),true);
        m_AbufferTest = GUILayout.Button("ABuffer测试");
        if (m_AbufferTest)
        {

        }
        serializedObject.ApplyModifiedProperties();
    }
}
