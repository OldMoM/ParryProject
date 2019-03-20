using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(bl_HierarchyData))]
public class bl_HierarchyDataEditor : Editor
{

    private ReorderableList TagList;

    void OnEnable()
    {
        TagList = new ReorderableList(serializedObject, serializedObject.FindProperty("m_HierarchyTagsIcons"), true, true, false, false);
        TagList.drawHeaderCallback = OnDrawHeader;
        TagList.drawElementCallback = OnDrawElement;
    }

    void OnDrawHeader(Rect rect)
    {
        rect.x += 15;
        EditorGUI.LabelField(rect, new GUIContent("Tag", ""), EditorStyles.boldLabel);
        rect.x += 125;
        EditorGUI.LabelField(rect, new GUIContent("Icon", ""), EditorStyles.boldLabel);
        rect.x += 150;
        EditorGUI.LabelField(rect, new GUIContent("Color", ""), EditorStyles.boldLabel);
    }

    void OnDrawElement(Rect rect, int index, bool isactive, bool isfocus)
    {
        var element = TagList.serializedProperty.GetArrayElementAtIndex(index);
        string  tag = element.FindPropertyRelative("Tag").stringValue;
        Color tint = element.FindPropertyRelative("TintColor").colorValue;
        rect.y += 2;

        EditorGUI.LabelField(new Rect(rect.x, rect.y, 125, EditorGUIUtility.singleLineHeight), tag, EditorStyles.toolbarButton);
        EditorGUI.PropertyField(new Rect(rect.x + 130, rect.y, 150, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("Icon"), GUIContent.none);
        tint = EditorGUI.ColorField(new Rect(rect.x + 285, rect.y, 100, EditorGUIUtility.singleLineHeight), new GUIContent("", ""), tint);
        element.FindPropertyRelative("Tag").stringValue = tag;
        element.FindPropertyRelative("TintColor").colorValue = tint;
    }

    public override void OnInspectorGUI()
    {
        bl_HierarchyData hd = (bl_HierarchyData)target;
        serializedObject.Update();
        TagList.DoLayoutList();
        serializedObject.ApplyModifiedProperties();

        GUILayout.BeginVertical("box");
        GUILayout.Label("Settings", EditorStyles.boldLabel);
        hd.ShowIcons = EditorGUILayout.ToggleLeft("Show Icons", hd.ShowIcons, EditorStyles.toolbarButton);
        hd.HorizontalPosition = EditorGUILayout.Slider("Horizontal Position", hd.HorizontalPosition,0,200);
        GUILayout.EndVertical();
        if (GUI.changed)
        {
            EditorUtility.SetDirty(hd);
        }
    }
}