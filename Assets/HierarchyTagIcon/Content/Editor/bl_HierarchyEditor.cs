using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[InitializeOnLoad]
public class bl_HierarchyEditor
{

    static List<int> sceneObjects;
    static bl_HierarchyData m_Data;

    /// <summary>
    /// 
    /// </summary>
    static bl_HierarchyEditor()
    {
        m_Data = Resources.Load("HierarchyData", typeof(bl_HierarchyData)) as bl_HierarchyData;
        EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchy;
        EditorApplication.projectWindowChanged += UpdateObjects;
        EditorApplication.hierarchyWindowChanged += UpdateObjects;
        EditorApplication.playmodeStateChanged += UpdateObjects;
    }

    /// <summary>
    /// 
    /// </summary>
    private static void UpdateObjects()
    {
        if (m_Data == null)
        {
            m_Data = Resources.Load("HierarchyData", typeof(bl_HierarchyData)) as bl_HierarchyData;
        }
        //This is for performance due this is called up to 4 times in each draw frame and we don't that

        // refresh tag list
        m_Data.RefreshTags();
        //get all objects in hierarchy (active objects).
        GameObject[] go = Object.FindObjectsOfType(typeof(GameObject)) as GameObject[];
        for (int i = 0; i < go.Length; i++)
        {
            m_Data.RegisterObject(go[i]);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    static void DrawHierarchy(int instanceID, Rect selectionRect)
    {
        if (m_Data == null)
            return;
        if (m_Data.isNull)
        {
            UpdateObjects();
            return;
        }
        if (!m_Data.ShowIcons)
            return;

        UpdateObjects();

        // place the icon to the right of the list:
        Rect r = new Rect(selectionRect);
        r.x = (r.width - 20) - m_Data.HorizontalPosition;
        r.width = 20;

        //if this object is in the list of tags with icon
        if (m_Data.ContainID(instanceID))
        {
            bl_HierarchyData.HierarchyTagsIcons t = m_Data.GetTagInfo(instanceID);
            if (t != null && t.Icon != null)
            {
                GUI.color = t.TintColor;
                GUI.Label(r, new GUIContent(t.Icon, t.Tag));
                GUI.color = Color.white;
            }
        }
    }

}