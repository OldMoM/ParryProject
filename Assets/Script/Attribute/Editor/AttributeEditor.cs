using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Attribute))]
public class AttributeEditor : Editor
{
    Attribute attribute;
    bool m_healthAttribute;
    bool m_damageAttribute;
    bool m_defenseAttribute;

    private void OnEnable()
    {
        attribute = (Attribute)target;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("在这里设置各种属性数值");
        EditorGUILayout.Space();

        attribute.type = EditorGUILayout.TextField("角色类型(很重要)", attribute.type);

        m_healthAttribute = EditorGUILayout.Foldout(m_healthAttribute, "生命值属性设置");
        if (m_healthAttribute)
        {
            attribute.max_health = EditorGUILayout.FloatField("最大生命值", attribute.max_health);
            attribute.current_health = EditorGUILayout.FloatField("当前生命值（只读）", attribute.current_health);
        }
        EditorGUILayout.Space();

        m_damageAttribute = EditorGUILayout.Foldout(m_damageAttribute, "伤害属性设置");
        if (m_damageAttribute)
        {
            attribute.atk = EditorGUILayout.FloatField("物理伤害", attribute.atk);
            attribute.fireDam = EditorGUILayout.FloatField("火焰伤害", attribute.fireDam);
            attribute.waterDam = EditorGUILayout.FloatField("水性伤害", attribute.waterDam);
            attribute.lightningDam = EditorGUILayout.FloatField("闪电伤害", attribute.lightningDam);
        }
        EditorGUILayout.Space();

        m_defenseAttribute = EditorGUILayout.Foldout(m_defenseAttribute, "防御属性设置");
        if (m_defenseAttribute)
        {
            attribute.def = EditorGUILayout.IntField("物理防御", attribute.def);
            attribute.antiFire = EditorGUILayout.IntSlider("火焰抗性（%）", attribute.antiFire, -100, 100);
            attribute.antiLightning = EditorGUILayout.IntSlider("雷电抗性（%）", attribute.antiLightning, -100, 100);
            attribute.antiWater = EditorGUILayout.IntSlider("水抗性（%）", attribute.antiWater, -100, 100);
        }

        serializedObject.ApplyModifiedProperties();
        EditorGUILayout.EndVertical();
    }
}
