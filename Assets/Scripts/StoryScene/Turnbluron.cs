using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Turnbluron : MonoBehaviour
{
    public Canvas prefab;

    private bool toggle = false;

    public GameObject Blurpanel_log;
    public void Blur_Set1()
    {
        toggle = !toggle;
        Blurpanel_log.SetActive(toggle);
    }
    public GameObject Blurpanel_setting;
    public void Blur_Set2()
    {
        toggle = !toggle;
        Blurpanel_setting.SetActive(toggle);
    }
}
