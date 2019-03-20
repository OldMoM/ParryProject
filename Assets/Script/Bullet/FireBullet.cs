using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : Bullet
{
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * muzzleVelocity * Time.deltaTime;
    }

    public override void InitializeBullet(Attribute m_attribute,string m_victiom)
    {
        base.InitializeBullet(m_attribute,m_victiom);
        fireDam = m_attribute.fireDam;
    }
}
