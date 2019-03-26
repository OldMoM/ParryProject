using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Attribute))]
public class AttributeEditor : Editor
{
    Attribute attribute;
    protected bool m_healthAttribute;
    protected bool m_damageAttribute;
    protected bool m_defenseAttribute;
    protected bool m_BuffSetting;


    private void OnEnable()
    {
        InitializeEditor();
    }

    public override void OnInspectorGUI()
    {
        DrawGUIAttribute(attribute);
    }

    public virtual void InitializeEditor()
    {
        attribute = (Attribute)target;
    }

    public virtual void DrawGUIAttribute(Attribute m_attribute)
    {
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("在这里设置各种属性数值");
        EditorGUILayout.Space();

        m_attribute.type = EditorGUILayout.TextField("角色类型(很重要)", m_attribute.type);
        EditorGUILayout.Space();

        m_healthAttribute = EditorGUILayout.Foldout(m_healthAttribute, "生命值属性设置");
        if (m_healthAttribute)
        {
            m_attribute.max_health = EditorGUILayout.FloatField("最大生命值", m_attribute.max_health);
            m_attribute.current_health = EditorGUILayout.FloatField("当前生命值（只读）", m_attribute.current_health);
        }
        EditorGUILayout.Space();

        m_damageAttribute = EditorGUILayout.Foldout(m_damageAttribute, "伤害属性设置");
        if (m_damageAttribute)
        {
            m_attribute.atk = EditorGUILayout.FloatField("物理伤害", m_attribute.atk);
            m_attribute.fireDam = EditorGUILayout.FloatField("火焰伤害", m_attribute.fireDam);
            m_attribute.waterDam = EditorGUILayout.FloatField("水性伤害", m_attribute.waterDam);
            m_attribute.lightningDam = EditorGUILayout.FloatField("闪电伤害", m_attribute.lightningDam);
        }
        EditorGUILayout.Space();

        m_defenseAttribute = EditorGUILayout.Foldout(m_defenseAttribute, "防御属性设置");
        if (m_defenseAttribute)
        {
            m_attribute.def = EditorGUILayout.IntField("物理防御", m_attribute.def);
            m_attribute.antiFire = EditorGUILayout.IntSlider("火焰抗性（%）", m_attribute.antiFire, -100, 100);
            m_attribute.antiLightning = EditorGUILayout.IntSlider("雷电抗性（%）", m_attribute.antiLightning, -100, 100);
            m_attribute.antiWater = EditorGUILayout.IntSlider("水抗性（%）", m_attribute.antiWater, -100, 100);
        }
        EditorGUILayout.Space();

        m_BuffSetting = EditorGUILayout.Foldout(m_BuffSetting, "Buff属性设置与查看");
        if (m_BuffSetting)
        {
            m_attribute.buff.max_buringAccum = EditorGUILayout.IntField("灼烧最大叠加数", m_attribute.buff.max_buringAccum);
            EditorGUILayout.IntField("当前灼烧叠加数（只读）", m_attribute.buff.current_burningAccum);
            m_attribute.buff.max_flameAccum = EditorGUILayout.IntField("引燃最大叠加数", m_attribute.buff.max_flameAccum);
            EditorGUILayout.IntField("当前引燃叠加数（只读）", m_attribute.buff.current_flameAccum);
        }
        EditorGUILayout.Space();


        serializedObject.ApplyModifiedProperties();
        EditorGUILayout.EndVertical();
    }
}
