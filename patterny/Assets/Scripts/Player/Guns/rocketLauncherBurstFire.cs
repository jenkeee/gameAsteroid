using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketLauncherBurstFire : MonoBehaviour
{

    private int curentLauncher = 0;
   // private int curentBulletIndex = 0;
    private Transform _poolBullet;
    private Transform _target;

    public float rocketSpeed;


    private void Start()
    {
        _poolBullet = Object.FindObjectOfType<poolOfbullet>().transform;
        _target = Object.FindObjectOfType<MouseAimReticle>().transform.GetChild(0).transform;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (curentLauncher > 1) curentLauncher = 0;

            Vector3 dirTotarget = _target.position - transform.GetChild(curentLauncher).position;
            Vector3 dirTotargetCamera = Camera.main.ScreenToWorldPoint(dirTotarget);
            dirTotargetCamera = dirTotargetCamera.normalized;

            for (int i = 0; i < _poolBullet.childCount; i++)
            {
                _poolBullet.GetChild(i).gameObject.SetActive(true);
                _poolBullet.GetChild(i).transform.position = transform.GetChild(curentLauncher).position + Vector3.back / 5 + new Vector3(Random.Range(-1f,1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                _poolBullet.GetChild(i).rotation = Quaternion.Euler(90, 0, 0);
                _poolBullet.GetChild(i).GetComponent<Rigidbody>().velocity = Vector3.zero;
                _poolBullet.GetChild(i).LookAt(dirTotargetCamera);
                _poolBullet.GetChild(i).GetComponent<Rigidbody>().AddForce(dirTotargetCamera * 1000 * Time.deltaTime * rocketSpeed);                
            }
            curentLauncher++;
        }

    }
}
