using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class LauncherUIManager : MonoBehaviour
{
    public static LauncherUIManager instance;
    public SpriteRenderer[] sprite;
    public SpriteAtlas atlas;
    public Sprite t;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="m_name">type of buttet</param>
    public void UILoadAmmo(Bullet m_bullet)
    {
        for (int i = 0; i < sprite.Length - 1; i++)
        {
            if (sprite[i].sprite == null)
            {
                Bullet bullet = m_bullet.GetComponent<Bullet>();
                if (bullet == null)
                {
                    throw new System.Exception("launcherUI failed to get script bullet");
                }
                else
                {
                    string m_type = m_bullet.GetComponent<Bullet>().bulletType;
                    sprite[i].sprite = atlas.GetSprite(m_type);
                }
                return;
            }
        }
    }

    public void UILoadAmmo(GameObject m_object)
    {
        for (int i = 0; i < sprite.Length; i++)
        {
            if (sprite[i].sprite == null)
            {
                Bullet bullet = m_object.GetComponent<Bullet>();
                if (bullet == null)
                {
                    throw new System.Exception("launcherUI failed to get script bullet");
                }
                else
                {
                    string m_type = m_object.GetComponent<Bullet>().bulletType;
                    sprite[i].sprite = atlas.GetSprite(m_type);
                }
                return;
            }
        }
    }

    public void UIShootAmmo()
    {
        for (int i = sprite.Length - 1; i >=0; i--)
        {
            if (sprite[i].sprite != null)
            {
                sprite[i].sprite = null;
                return;
            }
        }
    }
}
