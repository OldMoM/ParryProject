using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * muzzleVelocity * Time.deltaTime;
    }

    public override void InitializeBullet(Attribute m_attribute,string m_victim)
    {
        base.InitializeBullet(m_attribute, m_victim);
        iceDam = m_attribute.waterDam;
    }
}
