using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAimReticle : MonoBehaviour
{
    private Camera _camera;

    Vector2 mouseMove;
    public float sensetiveX;
    public float sensetiveY;

    private void Start()
    {
        _camera = Camera.main;
        mouseMove.x = Screen.width / 2; // - transform.GetChild(0).GetComponent<RectTransform>().rect.width/2
        mouseMove.y = Screen.height / 2;
        transform.GetChild(0).position = mouseMove;

    }
    void Update()
    {
        mouseMove.x += Input.GetAxis("Mouse X")* sensetiveX;
        mouseMove.y += Input.GetAxis("Mouse Y")* sensetiveY;
        transform.GetChild(0).position = mouseMove;

        if (Input.GetKeyDown(KeyCode.Mouse0))
            Cursor.lockState = CursorLockMode.Locked;
        else if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
    }
}
