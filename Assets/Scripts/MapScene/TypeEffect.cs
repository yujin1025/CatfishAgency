using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    Text TalkText;
    public GameObject talkText;
    public GameObject Cursor;
    public GameObject AudioSource;
    private AudioSource audioSource;
    private string targetMsg;
    public float CharPerSeconds;
    int index;
    public bool isAnim;

    private void Awake() {
        TalkText = talkText.GetComponent<Text>();
    }

    public void SetMsg(string msg)
    {
        if (isAnim) {
            TalkText.text = targetMsg;
            CancelInvoke();
            EffectEnd();
        }
        else {
            targetMsg = msg;
            EffectStart();
        }
    }

    void EffectStart()
    {
        TalkText.text = "";
        index = 0;
        Cursor.SetActive(false);
        audioSource = AudioSource.GetComponent<AudioSource>();
        audioSource.Play();

        isAnim = true;
        Invoke("Effecting", (float)1.0 / CharPerSeconds);
    }

    void Effecting()
    {
        if (TalkText.text == targetMsg) {
            EffectEnd();
            return;
        }
        TalkText.text += targetMsg[index];
        index++;
        Invoke("Effecting", (float)1.0 / CharPerSeconds);
    }

    void EffectEnd()
    {
        isAnim = false;
        Cursor.SetActive(true);
        if (audioSource) audioSource.Stop();
    }
}
