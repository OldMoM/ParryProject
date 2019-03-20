using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFireTemplate : MonoBehaviour
{
    public void FireTemplate()
    {
        CreateBullet();
        SetBulletDamage();
        ShowEffect();
        PlayAudio();
    }
    protected virtual void CreateBullet() { }
  
    protected virtual void SetBulletDamage() { }
 
    protected virtual void ShowEffect() { }
  
    protected virtual void PlayAudio() { }
 
}
