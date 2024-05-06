using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSFX : MonoBehaviour
{
    public GameObject ButtonClickSFX1;
    public GameObject ButtonClickSFX2;
    public AudioSource[] buttonClickSFX = new AudioSource[2];
    public int tmp;

    private void Awake() {
        ButtonClickSFX1 = GameObject.Find("ButtonClickSFX1");
        ButtonClickSFX2 = GameObject.Find("ButtonClickSFX2");
        buttonClickSFX[0] = ButtonClickSFX1.GetComponent<AudioSource>();
        buttonClickSFX[1] = ButtonClickSFX2.GetComponent<AudioSource>();
    }
    public void Click() {
        int tmp = Random.Range(0, 2);
        buttonClickSFX[tmp].Play();
    }
}