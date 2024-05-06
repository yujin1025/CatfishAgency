using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settingpanel : MonoBehaviour
{
    private bool toggle = false;

    public GameObject Setting_panel;

    public AudioMixer BGM;

    public Slider Slider_bgm;

    public Slider Slider_SFX;

    public void Panel_Set()
    {
        toggle = !toggle;
        Setting_panel.SetActive(toggle);
    }

    public void Sound_Control()
    {
        float volume = Slider_bgm.value;
        if (volume == -40f)
        {
            BGM.SetFloat("BGM", -80);
        }
        else
        {
            BGM.SetFloat("BGM", volume);
        }

    }
    

}

