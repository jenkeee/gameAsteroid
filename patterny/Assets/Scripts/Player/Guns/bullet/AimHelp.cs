using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AimHelp : MonoBehaviour
{
    [SerializeField]
    float maxRadius;
    [SerializeField] private LayerMask targetMask;
    [SerializeField] private LayerMask mostImportantTarget;

    [SerializeField] private Collider[] visiblTargets;

    bool findAster;

    // скорость автонаведения
    public float speed = 50.0f;

    int delayToChange= 2000;

#if UNITY_EDITOR
/*
    private void OnDrawGizmos()
    {
        Handles.color = new Color(1, 0, 1, 0.08f);
        Handles.DrawSolidArc(gameObject.transform.position, transform.up, transform.forward, 360, maxRadius);
    }*/
#endif

    private void Start()
    {
        maxRadius = 10f;
        targetMask = LayerMask.GetMask("Asteroids");
        mostImportantTarget = LayerMask.GetMask("Enemy");
    }

    private void FixedUpdate()
    {
        visiblTargets = Physics.OverlapSphere(transform.position, maxRadius, targetMask);

        if (visiblTargets.Length > 0)
        {
            transform.GetComponent<Rigidbody>().freezeRotation = false;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(visiblTargets[0].transform.position - transform.position), 5f * Time.deltaTime);            
            HelpAttack();
        }
        

    }

    void HelpAttack()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, visiblTargets[0].transform.position,step);
    }
}
