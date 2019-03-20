using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attribute : MonoBehaviour
{
    public float max_health;
    public float current_health;

    public float atk;
    public float fireDam;
    public float waterDam;
    public float lightningDam;

    public int def;
    public int antiFire;
    public int antiWater;
    public int antiLightning;

    public int current_burningAccum;//当前灼烧叠加数
    public int max_buringAccum = 1;//最大灼烧叠加层数
    public int current_flameAccum;//当前引燃层数
    public int max_flameAccum = 1;//最大引燃层数

    public string type = CharacterType.enemy;

    private void Start()
    {
        current_health = max_health;
    }

    public void AddHealth(float m_value)
    {
        current_health += m_value;
        if (current_health <= 0)
        {
            //died
        }
    }

    public virtual void Burning(float m_damange,float m_duration)
    {
        StartCoroutine(BurningDuration(m_damange,m_duration));
    }

    public virtual IEnumerator BurningDuration(float m_damange, float m_duration)
    {
        for (int i = 0; i < m_duration; i++)
        {
             current_health -= m_damange;
             //Debug.Log(i);
            if (i < m_duration)
            {
                if (i == m_duration - 1)
                {
                    //Debug.Log("end");
                    yield break;
                }
                yield return new WaitForSeconds(1);

            }
        }
    }
}
