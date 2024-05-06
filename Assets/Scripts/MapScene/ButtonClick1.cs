using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick1 : MonoBehaviour
{
    
    public GameObject Setting1;
    
    public void SettingSetActive()
    {
        Setting1.SetActive(!Setting1.activeSelf);
    }
    
}
