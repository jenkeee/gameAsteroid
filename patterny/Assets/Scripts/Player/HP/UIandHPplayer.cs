using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIandHPplayer : MonoBehaviour
{

    int hp = 100;
    Vector2 hpRectSize;

    private void Start()
    {
        hpRectSize = transform.GetChild(0).GetComponent<RectTransform>().sizeDelta;
    }
    public void DmgToPlayer(int dmg)
    {
        hp = hp - dmg;
        if (hp >= 100)
            hp = 100;
        else if (hp <= 0)
            hp = 0;
        BarHPcurrent();
    }

    void BarHPcurrent()
    {
        var get = transform.GetChild(0).GetComponent<RectTransform>().sizeDelta;
        get.x = hp * hpRectSize.x / 100;
        transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = get;
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = hp.ToString();        
    }


}
