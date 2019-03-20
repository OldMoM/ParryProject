using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Tooltip("子弹出膛速度")]
    public float muzzleVelocity = 5;
    public string bulletType = "normal";
    public string victimType = CharacterType.enemy;
    protected float atk;
    protected float fireDam;
    protected float iceDam;
    protected float lightningDam;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * muzzleVelocity * Time.deltaTime;
    }

    /// <summary>
    /// entitle bullet the capacity to damage and set victim
    /// </summary>
    /// <param name="m_attribute"></param>
    /// <param name="m_victim">victim's character type</param>
    public virtual void InitializeBullet(Attribute m_attribute,string m_victim)
    {
        victimType = m_victim;
        atk = m_attribute.atk;
        Destroy(gameObject, 2);
    }
}


