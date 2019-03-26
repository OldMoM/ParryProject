using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Buffs
{

    public int current_burningAccum;//当前灼烧叠加数
    public int max_buringAccum = 1;//最大灼烧叠加层数
    public int current_flameAccum;//当前引燃层数
    public int max_flameAccum = 1;//最大引燃层数

    public List<string> BuffsContainer = new List<string>();

    public void AddBuff(string m_name)
    {
        if (!BuffsContainer.Contains(m_name))
        {
            BuffsContainer.Add(m_name);
        }
    }

    public void RemoveBuff(string m_name)
    {
        if (BuffsContainer.Contains(m_name))
        {
            BuffsContainer.Remove(m_name);
        }
    }

    /// <summary>
    /// perform this when add a certain buff
    /// </summary>
    bool CheckCurrentBuff()
    {
        return true;
    }
}

public class BuffName
{
    public const string burn = "BurningBuff";
    public const string flame = "FlamingBuff";
    public const string oil = "OilSoakedBuff";
    public const string sluggish = "SluggishBuff";
}
