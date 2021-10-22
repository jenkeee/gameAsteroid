using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    private Transform gun_rocketLauncher;

    void Start()
    {
        gun_rocketLauncher = Object.FindObjectOfType<rocketLauncherFire>().transform;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            gun_rocketLauncher.GetComponent<rocketLauncherBurstFire>().enabled = false;
            gun_rocketLauncher.GetComponent<rocketLauncherFire>().enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            gun_rocketLauncher.GetComponent<rocketLauncherBurstFire>().enabled = true;
            gun_rocketLauncher.GetComponent<rocketLauncherFire>().enabled = false;
        }

    }
}
