using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroySound : MonoBehaviour
{
    public GameObject AnotherBGM_Map;
    public GameObject AnotherBGM_Ending;
    public AudioSource audio1;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void SceneChange()
    {
        AnotherBGM_Map = GameObject.Find("MapBGM");
        AnotherBGM_Ending = GameObject.Find("EndingBGM");
        if (audio1.isPlaying) {
            if (AnotherBGM_Map) audio1.Stop();
            else if (AnotherBGM_Ending) audio1.Stop();
        }
        else {
            if (AnotherBGM_Map) audio1.Stop();
            else if (AnotherBGM_Ending) audio1.Stop();
            else audio1.Play();
        }
    }
}
