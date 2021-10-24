using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    private Transform gun_rocketLauncher;
    private AimHelp[] _aimHelp;
    bool flagAimHelp = false;

    void Start()
    {
        gun_rocketLauncher = Object.FindObjectOfType<rocketLauncherFire>().transform;

    }

    public void RocketLauncherActive()
    {
        gun_rocketLauncher.GetComponent<rocketLauncherBurstFire>().enabled = false;
        gun_rocketLauncher.GetComponent<rocketLauncherFire>().enabled = true;
        areaWrapperSelectedWeapon.singleON();
    }
    public void rocketLauncherBurstActive()
    {
        gun_rocketLauncher.GetComponent<rocketLauncherBurstFire>().enabled = true;
        gun_rocketLauncher.GetComponent<rocketLauncherFire>().enabled = false;
        areaWrapperSelectedWeapon.burstON();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            RocketLauncherActive();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            rocketLauncherBurstActive();
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _aimHelp = Object.FindObjectOfType<poolOfbullet>().transform.GetComponentsInChildren<AimHelp>();

            if (!flagAimHelp)
            {
                foreach (AimHelp bullet in _aimHelp)
                {
                    bullet.GetComponent<AimHelp>().enabled = true;
                }
                flagAimHelp = true;
                areaWrapperSelectedWeapon.AimHelpON();
            }
            else if (flagAimHelp)
            {
                foreach (AimHelp bullet in _aimHelp)
                {
                    bullet.GetComponent<AimHelp>().enabled = false;
                }
                flagAimHelp = false;
                areaWrapperSelectedWeapon.AimHelpOff();
            }

        }

    }
}
