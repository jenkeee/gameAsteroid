using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketLauncherFire : MonoBehaviour
{
    private int curentLauncher=0;
    private int curentBulletIndex = 0;
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
            if (curentBulletIndex >= _poolBullet.childCount) curentBulletIndex = 0;
            if (curentLauncher > 1) curentLauncher = 0;
            var curentBullet = _poolBullet.GetChild(curentBulletIndex);
            curentBullet.gameObject.SetActive(true);
            curentBullet.position = transform.GetChild(curentLauncher).position + Vector3.back/5;
            curentBullet.rotation = Quaternion.Euler(90, 0, 0);
            curentBullet.GetComponent<Rigidbody>().velocity = Vector3.zero;


            Vector3 dirTotarget = _target.position - transform.GetChild(curentLauncher).position;            
            Vector3 dirTotargetCamera = Camera.main.ScreenToWorldPoint(dirTotarget);
            dirTotargetCamera = dirTotargetCamera.normalized;
            Debug.Log(dirTotargetCamera);
            curentBullet.LookAt(dirTotargetCamera);
            curentBullet.GetComponent<Rigidbody>().AddForce(dirTotargetCamera * 1000 * Time.deltaTime * rocketSpeed) ;

            curentBulletIndex++;
            curentLauncher++;

        }

        /*if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            for (int i = 0; i < _poolBullet.childCount; i++)
            {
                _poolBullet.GetChild(i).gameObject.SetActive(true);
                _poolBullet.GetChild(i).transform.position = transform.GetChild(0).position+ Vector3.forward;
                _poolBullet.GetChild(i).GetComponent<Rigidbody>().AddForce(Vector3.forward*10,ForceMode.Impulse);
            }
        }*/

    }
}
