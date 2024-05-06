using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Log : MonoBehaviour
{
    private bool toggle = false;

    public GameObject Log_panel;
    public void Panel_Set()
    {
        toggle = !toggle;
        Log_panel.SetActive(toggle);
    }
}
