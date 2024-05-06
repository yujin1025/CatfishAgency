using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScript : MonoBehaviour
{
    public GameObject setting1;
    public GameObject setting2;
    public GameObject setting3;
    public GameObject dialogOn;
    public GameObject dialogOff;
    public bool isShown;

    public void SettingScript()
    {
        setting1.SetActive(!setting1.activeSelf);
        setting2.SetActive(!setting2.activeSelf);
        setting3.SetActive(!setting3.activeSelf);

        if (setting1.activeSelf==false)
        {
            dialogOn.SetActive(true);
            dialogOff.SetActive(false);
            isShown = false;
        }
        else
        {
            dialogOn.SetActive(false);
            dialogOff.SetActive(true);
            isShown = true;
        }
    }
}
