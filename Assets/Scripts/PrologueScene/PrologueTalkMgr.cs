using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrologueTalkMgr : MonoBehaviour
{
    public prologue prologue;
    Text TalkText;
    public GameObject talkText;
    public GameObject Cursor;
    public GameObject AudioSource;
    private AudioSource audioSource;
    private AudioSource nextPage;
    private string targetMsg;
    public float CharPerSeconds;
    int index;
    public bool isAnim;
    public int talkNum;
    public bool noteDisappear = false;

    private string[] talkData = {
        "그르릉..하암..",
        "으.. 쭈우우욱!!",
        "응? 다들 어디 가신 거지?",
        "오잉? 웬 쪽지가 있담..",
        "무슨 내용이지?",
        "아! 맞다 오늘 간다고 하셨었지! 으음..",
        "내가 과연 가게를 잘 맡을 수 있을까..?",
        "이 쪽지를 보면 되겠다!",
        "고양이 손님들이 찾아오면..",
        "물고기 물어보고.. 또 찾아가서 데려오기! 메모!",
        "이내, 나나, 라이.. 그렇구나",
        "명부를 한 번 봐야겠다!",
        "앗!",
        "헉! 안돼! 중요한 명부인데!",
        "어.. 물고기 손님들의 주소가..",
        "다 지워져 버렸잖아!",
        "어쩌지..?",
        "우.. 우선 주소는 다 물고기 손님들이 살 법한 곳이었겠지..?",
        "괜찮을 거야! 직접 찾아가서 물어보면..",
        "어떻게든 되겠지! 되지 않을까..?"
    };

    private void Awake() {
        TalkText = talkText.GetComponent<Text>();
        nextPage = gameObject.GetComponent<AudioSource>();
        talkNum = 0;
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

    public void PanelTouch() {
        if (isAnim) {
            TalkText.text = targetMsg;
            CancelInvoke();
            EffectEnd();
        }
        else if (talkNum == 4 ||
                talkNum == 6 || talkNum == 7 ||
                (talkNum >= 9 && talkNum <= 11) ||
                (talkNum >= 13 && talkNum <= 19))
        {
            KeepGoing();
        }
        else {
            if (talkNum == 8 || talkNum == 12) {
                noteDisappear = true;
            }
            prologue.PanelClick();
        }
    }

    public void KeepGoing() {
        if (talkData.Length == talkNum) {
            SceneManager.LoadScene("MainScene");
            return;
        }
        SetMsg(talkData[talkNum]);
        nextPage.Play();
        talkNum++;
    }
}
