using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupButton : MonoBehaviour
{
    private bool toggle = false;
    public GameObject panel;
    public void Panel_Set() {
        toggle = !toggle;
        panel.SetActive(toggle);
    }
}
