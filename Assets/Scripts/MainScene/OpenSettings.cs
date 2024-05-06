using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettings : MonoBehaviour
{
    public GameObject Settings, Exit_button;

    void Update()
    {
        Exit_button.SetActive(false);
        Settings.SetActive(true);
    }
}
