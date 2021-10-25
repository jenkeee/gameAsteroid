using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    float horizontal;
    float vertical;
    public float speed = 1;

    private Transform _target;

    private void Start()
    {
        _target = Object.FindObjectOfType<MouseAimReticle>().transform.GetChild(0).transform;
    }

    void Update()
    {
      /*переведем скрин позицию прицела в игровые корды*/  Vector3 dirTotarget = _target.position - transform.position;
        Vector3 dirTotargetCamera = Camera.main.ScreenToWorldPoint(dirTotarget);
        dirTotargetCamera = -dirTotargetCamera.normalized;

        transform.LookAt(dirTotargetCamera);

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(-horizontal, vertical, 0);
        if (transform.position.x <= 10 && transform.position.x >= -10 && transform.position.y >= -10 && transform.position.y <= 10)
        {
            transform.position += move.normalized * speed * Time.deltaTime;
        }
        else if (transform.position.x > 10)
        {
            transform.position -= new Vector3(0.1f,0,0);
        }
        else if (transform.position.x < -10)
        {
            transform.position += new Vector3(0.1f, 0, 0);
        }
        else if (transform.position.y < -10)
        {
            transform.position += new Vector3(0, 0.1f, 0);
        }
        else if (transform.position.y > 10)
        {
            transform.position -= new Vector3(0, 0.1f, 0);
        }


    }
}
