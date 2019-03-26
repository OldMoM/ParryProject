using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerAttribute))]
public class PlayerAttributeEditor : AttributeEditor
{
    PlayerAttribute attribute;
    bool m_specialAttribute;

    float buringDuration = 2;
    float buringDamage = 5;

    private void OnEnable()
    {
        InitializeEditor();
    }

    public override void OnInspectorGUI()
    {
        DrawGUIAttribute(attribute);
    }

    public override void InitializeEditor()
    {
        attribute = (PlayerAttribute)target;
    }

    public override void DrawGUIAttribute(Attribute m_attribute)
    {
        base.DrawGUIAttribute(attribute);
        EditorGUILayout.Space();

        m_specialAttribute = EditorGUILayout.Foldout(m_specialAttribute, "玩家特有的属性设置");
        if (m_specialAttribute)
        {
            attribute.ammoCapacity = EditorGUILayout.IntField("最大弹容量", attribute.ammoCapacity);
            attribute.fireRate = EditorGUILayout.Slider("射速（次/秒）", attribute.fireRate, 0, 5);
        }
        EditorGUILayout.Space();

        buringDuration = EditorGUILayout.FloatField("燃烧时间", buringDuration);
        buringDamage = EditorGUILayout.FloatField("燃烧伤害", buringDamage);
        if (GUILayout.Button("测试燃烧效果"))
        {
            m_attribute.Burning(buringDamage, buringDuration);
        }
    }

}
