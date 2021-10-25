using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAimReticle : MonoBehaviour
{
    private Camera _camera;

    Vector3 mouseMove;
    public float sensetiveX;
    public float sensetiveY;
    public int deepOfReticle;
    private void Start()
    {
        _camera = Camera.main;
        mouseMove.x = Screen.width / 2; // - transform.GetChild(0).GetComponent<RectTransform>().rect.width/2
        mouseMove.y = Screen.height / 2;
        transform.GetChild(0).position = mouseMove;
        Debug.Log(mouseMove);

    }
    void Update()
    {
        if (transform.GetChild(0).position.x < Screen.width && transform.GetChild(0).position.x > 0)
            mouseMove.x += Input.GetAxis("Mouse X") * sensetiveX;
        else if (transform.GetChild(0).position.x >= Screen.width)
            mouseMove.x -= 1.0f;
        else if (transform.GetChild(0).position.x <= 0)
            mouseMove.x += 1.0f;


        if (transform.GetChild(0).position.y < Screen.height && transform.GetChild(0).position.y > 0)
            mouseMove.y += Input.GetAxis("Mouse Y") * sensetiveY;
         else if (transform.GetChild(0).position.y >= Screen.height)
            mouseMove.y -= 1.0f;
        else if (transform.GetChild(0).position.y <= 0)
            mouseMove.y += 1.0f;

        /*
        mouseMove.y += Input.GetAxis("Mouse Y")* sensetiveY;*/

        /*
                if (transform.GetChild(0).position.x < Screen.width / 2 && transform.GetChild(0).position.x > -Screen.width / 2)
                    mouseMove.x += Input.GetAxis("Mouse X") * sensetiveX;
                else if (transform.GetChild(0).position.x > Screen.width / 2 && transform.GetChild(0).position.x < -Screen.width / 2)
                    mouseMove.x -= Input.GetAxis("Mouse X") * sensetiveX;*/



        mouseMove.z = deepOfReticle; // без глубины не работает Camera.main.ScreenToWorldPoint(dirTotarget);
        transform.GetChild(0).position = mouseMove;        
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Cursor.lockState = CursorLockMode.Locked;
        else if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
    }
}
