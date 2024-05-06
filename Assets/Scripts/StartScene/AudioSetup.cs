using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSetup : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer BGM;
    public AudioMixer SFX;
    public Slider BGM_Slider;
    public Slider SFX_Slider;
    public DontDestroySound Mainbgm;

    void Awake() {
        float value;
        bool result = BGM.GetFloat("BGM", out value);
        if (result) BGM_Slider.value = value;
        else BGM_Slider.value = 0f;

        result = SFX.GetFloat("SFX", out value);
        if (result) SFX_Slider.value = value;
        else SFX_Slider.value = 0f;

        GameObject Tmp = GameObject.Find("MainBGM(DontDestroy)");
        if (Tmp) {
            Mainbgm = Tmp.GetComponent<DontDestroySound>();
            Mainbgm.SceneChange();
        }
    }
    
    public void BGM_Sound_Control() {
        float volume = BGM_Slider.value;
        if (volume == -40f)
            BGM.SetFloat("BGM", -80);
        else
            BGM.SetFloat("BGM", volume);
    }
    public void SFX_Sound_Control() {
        float volume = SFX_Slider.value;
        if (volume == -40f)
            SFX.SetFloat("SFX", -80);
        else
            SFX.SetFloat("SFX", volume);
    }
}
