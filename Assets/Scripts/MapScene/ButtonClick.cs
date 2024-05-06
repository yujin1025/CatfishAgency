using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject lightOn;
    public GameObject lightOff;


    public void SettingSetActive1()
    {
        button1.SetActive(!button1.activeSelf);
        button2.SetActive(false);
        button3.SetActive(false);
    }

    public void SettingSetActive2()
    {
        button1.SetActive(false);
        button2.SetActive(!button2.activeSelf);
        button3.SetActive(false);

        if (button2.activeSelf == false)
        {
            lightOn.SetActive(true);
            lightOff.SetActive(false);
        }
        else
        {
            lightOn.SetActive(false);
            lightOff.SetActive(true);
        }
    }
    public void SettingSetActive3()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(!button3.activeSelf);
    }
}
