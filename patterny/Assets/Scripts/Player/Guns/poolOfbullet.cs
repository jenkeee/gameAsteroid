using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolOfbullet : MonoBehaviour
{
    [SerializeField]
    int rocketCount = 10;

    [SerializeField]
    GameObject rocketPrefab;

    private int curentLauncher = 0;
    void Start()
    {
        for (int i = 0; i < rocketCount; i++)
        {
            var obgAster = GameObject.Instantiate(rocketPrefab, new Vector3(0, -1000, 0), Quaternion.identity).transform;
            obgAster.SetParent(transform);
            obgAster.name = $"rocket {i}";
            obgAster.gameObject.SetActive(false);
            obgAster.gameObject.AddComponent<Rigidbody>();
            obgAster.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            obgAster.GetComponent<Rigidbody>().useGravity = false;
        }

    }
}
