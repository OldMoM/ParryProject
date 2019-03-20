using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute : Attribute
{
    public float fireRate;
    public int ammoCapacity;

    // Start is called before the first frame update
    void Start()
    {
        type = CharacterType.player;
        PlayerUIManager.instance.UpdatePlayerAttribute(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Burning(float m_damange, float m_duration)
    {
        StartCoroutine(BurningDuration(m_damange, m_duration));
    }

    public override IEnumerator BurningDuration(float m_damange, float m_duration)
    {
        for (int i = 0; i < m_duration; i++)
        {
            current_health -= m_damange;
            //Debug.Log(i);
            PlayerUIManager.instance.UpdatePlayerAttribute(this);
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
