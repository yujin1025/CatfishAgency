using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick2 : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;

    public void SettingSetActive1()
    {
        button1.SetActive(!button1.activeSelf);
        button2.SetActive(false);
    }

    public void SettingSetActive2()
    {
        button1.SetActive(false);
        button2.SetActive(!button2.activeSelf);
    }

}
