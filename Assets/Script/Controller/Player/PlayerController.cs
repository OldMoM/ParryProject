using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2;
    SpriteRenderer launcherSprite;
    Vector3 direction;

    Vector3 mousePosOnScreen;
    Vector3 mousePosInWorld;

    float faceDir;
    float fireTimer = 10;

    public Transform launcher;

    PlayerAttribute attribute;
    LauncherController launcherController;
    // Start is called before the first frame update
    void Start()
    {
        attribute = GetComponent<PlayerAttribute>();
        launcherController = GetComponentInChildren<LauncherController>();
        launcherSprite = launcher.GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        direction.x = InputSystem.instance.RightMove;
        direction.y = InputSystem.instance.UpMove;

        transform.position += direction.normalized * speed * Time.deltaTime;

        //calculate mouse position
        mousePosOnScreen = Input.mousePosition;
        mousePosInWorld = Camera.main.ScreenToWorldPoint(mousePosOnScreen);
        mousePosInWorld.z = 0;
        
        //turn face and launcher
        faceDir = (mousePosInWorld.x > transform.position.x) ? 1 : -1;
        if (faceDir == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            launcher.right = (mousePosInWorld - transform.position).normalized;
            launcherSprite.flipY = false;
        }
        else if (faceDir == -1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            launcher.right = (mousePosInWorld - transform.position).normalized;
            launcherSprite.flipY = true;
        }

        //open fire
        if (InputSystem.instance.Fire)
        {
            OpenFire();
        }
    }

    void OpenFire()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer >= attribute.fireRate)
        {
            fireTimer = 0;
            launcherController.Fire();
        }
    }
}
