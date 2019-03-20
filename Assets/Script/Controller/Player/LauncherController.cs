using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : BaseFireTemplate
{
    public Transform muzzle;
    public GameObject bullet;
    public Stack<GameObject> magazine = new Stack<GameObject>();
    PlayerAttribute attribute;

    public List<GameObject> arsenal;

    int max_magezine;
    // Start is called before the first frame update
    void Start()
    {
        attribute = GetComponentInParent<PlayerAttribute>();
        SetMaxMagazine(attribute.ammoCapacity);
    }

    /// <summary>
    /// referenced by script PlayerController and excutive father's FireTemplat()
    /// </summary>
    public void Fire()
    {
        FireTemplate();
    }

    public void LoadAmmo(GameObject m_bullet)
    {
        if (magazine.Count<max_magezine)
        {
            magazine.Push(m_bullet);
            LauncherUIManager.instance.UILoadAmmo(m_bullet);
        }
    }

    /// <summary>
    /// 1=FireBullet;2=IceBullet;3=LightBullet
    /// 0=NormalBullet
    /// </summary>
    /// <param name="n"></param>
    public void LoadAmmo(int n)
    {
        if (magazine.Count < max_magezine)
        {
            if (n>arsenal.Count)
            {
                throw new System.Exception("n is out of the index of arsenal, make sure n is within");
            }
            magazine.Push(arsenal[n]);
            LauncherUIManager.instance.UILoadAmmo(arsenal[n]);
        }
    }

    public void SetMaxMagazine(int m)
    {
        max_magezine = m;
    }

    #region//block overrided
    protected override void CreateBullet()
    {
        base.CreateBullet();
        //shot normal ammo
        if (magazine.Count == 0)
        {
            GameObject m_bullet = Instantiate(bullet, muzzle.position, transform.rotation);
            m_bullet.GetComponent<Bullet>().InitializeBullet(attribute, CharacterType.enemy);
        }
        //shot special ammo
        else
        {
            GameObject m_specialBullet = Instantiate((GameObject)magazine.Pop(), muzzle.position, transform.rotation);
            m_specialBullet.GetComponent<Bullet>().InitializeBullet(attribute, CharacterType.enemy);
            LauncherUIManager.instance.UIShootAmmo();
        }
    }

    protected override void PlayAudio()
    {
        base.PlayAudio();
    }

    protected override void SetBulletDamage()
    {
        base.SetBulletDamage();
    }

    protected override void ShowEffect()
    {
        base.ShowEffect();
    }
    #endregion
}
