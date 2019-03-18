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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
