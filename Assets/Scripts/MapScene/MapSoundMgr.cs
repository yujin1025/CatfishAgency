using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MapSoundMgr : MonoBehaviour
{
    public Slider mine;
    public Slider other;

    public void MapSliderSetUp() {
        other.value = mine.value;
    }
}
