using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    public float xAxis;
    public float yAxis;
    public float zAxis;
    public float folowSpeed;
    public float yLookAt;

    void Update()
    {
 
            transform.position = Vector3.MoveTowards(transform.position, Player.position + new Vector3(xAxis, yAxis, zAxis), folowSpeed * Time.deltaTime);
       
        transform.LookAt(Player.transform.position+ Vector3.up* yLookAt);
    }
}
