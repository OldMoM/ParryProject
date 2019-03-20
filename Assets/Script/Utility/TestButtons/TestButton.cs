using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    private LauncherController launcher;
    private PlayerAttribute pa;

    private void Start()
    {
        launcher = FindObjectOfType<LauncherController>();
        pa = FindObjectOfType<PlayerAttribute>();
    }
    private void OnGUI()
    {
        if (GUILayout.Button("添加火子弹",GUILayout.Width(150),GUILayout.Height(50)))
        {
            launcher.LoadAmmo(launcher.arsenal[1]);
        }

        if (GUILayout.Button("添加冰子弹", GUILayout.Width(150), GUILayout.Height(50)))
        {
            launcher.LoadAmmo(launcher.arsenal[2]);
        }

        if (GUILayout.Button("添加电子弹", GUILayout.Width(150), GUILayout.Height(50)))
        {
            launcher.LoadAmmo(launcher.arsenal[3]);
        }

        if (GUILayout.Button("减少生命10",GUILayout.Width(150),GUILayout.Height(50)))
        {
            pa.AddHealth(-10);
        }

        if (GUILayout.Button("灼烧玩家", GUILayout.Width(150), GUILayout.Height(50)))
        {

        }
    }
}
