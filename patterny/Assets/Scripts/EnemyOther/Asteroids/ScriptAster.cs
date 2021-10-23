using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAster : MonoBehaviour
{
    [SerializeField]
    int asteroidCount = 20;

    [SerializeField]
    GameObject asteroidPrefab;

    [SerializeField]
    float asteroidSpeed = 20f;
    [SerializeField]
    float minSizeX = 1f;

    [SerializeField]
    [Tooltip("Разброс стартовой позиции по X")]
    int xSpread = 20;
    [SerializeField]
    [Tooltip("Разброс стартовой позиции по Y")]
    int ySpread = 20;
    [SerializeField]
    [Tooltip("минимальная Z спавна астероидов// -300")]
    int startPosAst = -300;

    float Xaxis= 0;
    float Yaxis= 0;
    float Zaxis= 0;

    private void Awake()
    {
        for (int i = 0; i < asteroidCount; i++)
        {
            var obgAster = GameObject.Instantiate(asteroidPrefab, new Vector3(0, -1000, 0), Quaternion.identity).transform;
            obgAster.SetParent(transform);
            obgAster.name = $"Asteroid {i}";
        }
    }

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
            transform.GetChild(i).localScale = RandomScaleWithAddiction();
            transform.GetChild(i).position = new Vector3(Random.Range(-xSpread, xSpread), Random.Range(-ySpread, ySpread), Random.Range(-500, -900));
            transform.GetChild(i).gameObject.layer = 6;
        }

    }


    //генератор размеров
    private Vector3 RandomScaleWithAddiction()
    {
        float x = Random.Range(minSizeX, minSizeX + 8);
        float y;
        float z;
        if (x >= minSizeX && x < minSizeX + 3)
        {
            y = Random.Range(minSizeX, minSizeX + 5);
            z = Random.Range(minSizeX, minSizeX + 5);
        }
        else if (x >= minSizeX + 3 && x < minSizeX + 6)
        {
            y = Random.Range(minSizeX + 3, minSizeX + 8);
            z = Random.Range(minSizeX + 3, minSizeX + 8);
        }
        else if (x >= minSizeX + 6 && x <= minSizeX + 8)
        {
            y = Random.Range(minSizeX + 6, minSizeX + 8);
            z = Random.Range(minSizeX + 6, minSizeX + 8);
        }
        else { y = x; z = x; }

        return new Vector3(x, y, z);
    }
    private Vector3 SetPosToStart()
    { return new Vector3(Random.Range(-xSpread, xSpread), Random.Range(-ySpread, ySpread), Random.Range(startPosAst, startPosAst - 400)); }

    private void Update()
    {

        Vector3 move = new Vector3(0, 0, asteroidSpeed * Time.deltaTime);

        for (int i = 0; i < transform.childCount; i++)
        {
            if (i % 2 == 0)
            {
                Xaxis += 0.1f * Time.deltaTime;
                Yaxis += 0.1f * Time.deltaTime; 
                Zaxis += 0.1f * Time.deltaTime; 

                transform.GetChild(i).position += move;        
            transform.GetChild(i).rotation = Quaternion.Euler(Xaxis, Yaxis, Zaxis);             

            }
            else {
                Xaxis += 0.2f * Time.deltaTime; 
                Yaxis += 0.2f * Time.deltaTime;
                Zaxis += 0.2f * Time.deltaTime;
                transform.GetChild(i).position += move/2;
                transform.GetChild(i).rotation = Quaternion.Euler(Xaxis, Yaxis, Zaxis);                
            }


            if (transform.GetChild(i).position.z > 10)
            {
                transform.GetChild(i).localScale = RandomScaleWithAddiction();
                transform.GetChild(i).position = SetPosToStart();
            }
        }
        //добавляем астероид, если понадобится 
        if (false) // для теста Input.GetKeyDown(KeyCode.Space)
        {
            var obgAster = GameObject.Instantiate(asteroidPrefab, SetPosToStart(), Quaternion.identity).transform;
            obgAster.SetParent(transform);
            obgAster.name = $"Asteroid {transform.childCount-1}";
        }
    }

}
