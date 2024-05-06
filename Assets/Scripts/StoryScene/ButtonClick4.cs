using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick4 : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;

    public void SettingSetActive1()
    {
        button1.SetActive(!button1.activeSelf);
        button2.SetActive(!button2.activeSelf);
        button3.SetActive(false);
        button4.SetActive(false);
    }

    public void SettingSetActive2()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(!button3.activeSelf);
        button4.SetActive(!button4.activeSelf);
    }
}
