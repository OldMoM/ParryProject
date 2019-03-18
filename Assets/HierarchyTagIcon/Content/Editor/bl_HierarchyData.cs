using UnityEngine;
using System.Collections.Generic;
using UnityEditorInternal;

public class bl_HierarchyData : ScriptableObject
{
    [Header("Tags")]
    public List<HierarchyTagsIcons> m_HierarchyTagsIcons = new List<HierarchyTagsIcons>();

    [Header("Settings")]
    public bool ShowIcons = true;
    [Range(0,200)]public float HorizontalPosition = 0;

    private List<string> Tags = new List<string>();
    private Dictionary<int, HierarchyTagsIcons> FullIDList = new Dictionary<int, HierarchyTagsIcons>();

    /// <summary>
    /// 
    /// </summary>
    public void RefreshTags()
    {
        ClearAll();
        Tags.AddRange(InternalEditorUtility.tags);
        for (int i = 0; i < Tags.Count; i++)
        {
            if (!ContainsTag(Tags[i]))
            {
                HierarchyTagsIcons hti = new HierarchyTagsIcons();
                hti.Tag = Tags[i];
                m_HierarchyTagsIcons.Add(hti);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="go"></param>
    public void RegisterObject(GameObject go)
    {
        string tag = go.tag;
        for (int i = 0; i < m_HierarchyTagsIcons.Count; i++)
        {
            if(m_HierarchyTagsIcons[i].Tag == tag)
            {
                int id = go.GetInstanceID();
                if (!m_HierarchyTagsIcons[i].IDs.ContainsKey(id))
                {
                    m_HierarchyTagsIcons[i].IDs.Add(id,CreateInfo(go));
                    FullIDList.Add(id, m_HierarchyTagsIcons[i]);
                }
            }
        }
    }

    private HierarchyObjectInfo CreateInfo(GameObject go)
    {
        HierarchyObjectInfo hoi = new HierarchyObjectInfo();
        hoi.Name = go.name;
        return hoi;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool ContainID(int id)
    {
        return FullIDList.ContainsKey(id);
    }

    /// <summary>
    /// 
    /// </summary>
    public bool isNull
    {
        get
        {
            return (m_HierarchyTagsIcons == null || m_HierarchyTagsIcons.Count <= 0);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void ClearAll()
    {
        Tags.Clear();
        FullIDList.Clear();
        for (int i = 0; i < m_HierarchyTagsIcons.Count; i++)
        {
            m_HierarchyTagsIcons[i].IDs.Clear();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public HierarchyTagsIcons GetTagInfo(int id)
    {
        return FullIDList[id];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    private bool ContainsTag(string tag)
    {
        if (m_HierarchyTagsIcons.Count <= 0) { return false; }
        for (int i = 0; i < m_HierarchyTagsIcons.Count; i++)
        {
            if (m_HierarchyTagsIcons[i].Tag == tag)
            {
                return true;
            }
        }
        return false;
    }

    [System.Serializable]
    public class HierarchyTagsIcons
    {
        public string Tag;
        public Texture2D Icon;
        public Color TintColor = Color.white;
        public Dictionary<int,HierarchyObjectInfo> IDs = new Dictionary<int, HierarchyObjectInfo>();
    }

    [System.Serializable]
    public class HierarchyObjectInfo
    {
        public string Name;
        public int VertCount;
    }
}