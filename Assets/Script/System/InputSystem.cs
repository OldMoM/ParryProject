using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public static InputSystem instance;

    float rightMove;
    float upMove;

    bool fire;

    public float RightMove
    {
        get { return rightMove; }
    }
    public float UpMove
    {
        get { return upMove; }
    }
    public bool Fire
    {
        get { return fire; }
    }


    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        rightMove = Input.GetAxisRaw("Horizontal");
        upMove = Input.GetAxisRaw("Vertical");
        fire = Input.GetButton("Fire1");
    }
}
