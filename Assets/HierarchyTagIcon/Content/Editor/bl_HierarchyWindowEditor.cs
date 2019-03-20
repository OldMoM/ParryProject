using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

public class bl_HierarchyWindowEditor : EditorWindow
{
    static bl_HierarchyData m_Data;
    private ReorderableList TagList;
    private SerializedObject DataSerialized;

    void OnEnable()
    {
        m_Data = Resources.Load("HierarchyData", typeof(bl_HierarchyData)) as bl_HierarchyData;
        if (m_Data != null)
        {
            DataSerialized = new SerializedObject(m_Data);
            TagList = new ReorderableList(DataSerialized, DataSerialized.FindProperty("m_HierarchyTagsIcons"), true, true, false, false);
            TagList.drawHeaderCallback = OnDrawHeader;
            TagList.drawElementCallback = OnDrawElement;
        }
    }

    void OnGUI()
    {
        if (m_Data != null) {
            DataSerialized.Update();
            TagList.DoLayoutList();
            DataSerialized.ApplyModifiedProperties();

            GUILayout.BeginVertical("box");
            GUILayout.Label("Settings", EditorStyles.boldLabel);
            m_Data.ShowIcons = EditorGUILayout.ToggleLeft("Show Icons", m_Data.ShowIcons, EditorStyles.toolbarButton);
            m_Data.HorizontalPosition = EditorGUILayout.Slider("Horizontal Position", m_Data.HorizontalPosition, 0, 200);
            GUILayout.EndVertical();
            if (GUI.changed)
            {
                EditorUtility.SetDirty(m_Data);
            }
        }
        else
        {
            GUILayout.Label("Data not found.", EditorStyles.boldLabel);
        }
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
        string tag = element.FindPropertyRelative("Tag").stringValue;
        Color tint = element.FindPropertyRelative("TintColor").colorValue;
        rect.y += 2;

        EditorGUI.LabelField(new Rect(rect.x, rect.y, 125, EditorGUIUtility.singleLineHeight), tag, EditorStyles.toolbarButton);
        EditorGUI.PropertyField(new Rect(rect.x + 130, rect.y, 150, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("Icon"), GUIContent.none);
        tint = EditorGUI.ColorField(new Rect(rect.x + 285, rect.y, 100, EditorGUIUtility.singleLineHeight), new GUIContent("", ""), tint);
        element.FindPropertyRelative("Tag").stringValue = tag;
        element.FindPropertyRelative("TintColor").colorValue = tint;
    }

    [MenuItem("Window/Hierarchy Icons")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindowWithRect(typeof(bl_HierarchyWindowEditor), new Rect(300, 300, 450, 700),true,"Hierarchy Icons");
    }
}