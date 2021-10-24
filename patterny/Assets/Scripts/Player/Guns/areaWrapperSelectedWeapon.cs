using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class areaWrapperSelectedWeapon : MonoBehaviour
{
    static private GameObject textAimHelp;
    static private GameObject textFireMode;
    private void Awake()
    {
        textAimHelp = FindObjectOfType<areaWrapperSelectedWeapon>().transform.Find("textAimFire").gameObject;
        AimHelpOff();
        textFireMode = FindObjectOfType<areaWrapperSelectedWeapon>().transform.Find("textFireMode").gameObject;
    }

    public static void AimHelpON()
    {        
        textAimHelp.GetComponent<Text>().color = new Color(0.2352941f, 0.4823529f, 0.2117647f, 1);
        textAimHelp.GetComponent<Text>().text = "AimHelp || oN";
    }
    public static void AimHelpOff()
    { 
        textAimHelp.GetComponent<Text>().color = new Color(0.3882353f, 0.08235294f, 0.1176471f);
        textAimHelp.GetComponent<Text>().text = "AimHelp || oFF";
    }
    public static void singleON()
    {
        Color tmpA = textFireMode.transform.GetChild(0).GetComponent<Image>().color;
        tmpA.a = 255;
        textFireMode.transform.GetChild(0).GetComponent<Image>().color = tmpA;

        Color tmpB = textFireMode.transform.GetChild(1).GetComponent<Image>().color;
        tmpB.a = 0;
        textFireMode.transform.GetChild(1).GetComponent<Image>().color = tmpB;
    }
    public static void burstON()
    {
        Color tmpA = textFireMode.transform.GetChild(0).GetComponent<Image>().color;
        tmpA.a = 0;
        textFireMode.transform.GetChild(0).GetComponent<Image>().color = tmpA;

        Color tmpB = textFireMode.transform.GetChild(1).GetComponent<Image>().color;
        tmpB.a = 255;
        textFireMode.transform.GetChild(1).GetComponent<Image>().color = tmpB;
    }
}
