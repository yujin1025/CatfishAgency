using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoMgr : MonoBehaviour
{
    // 각 색의 메모 위에 돋보기가 떠 있어야 하는지
    public bool yellow;
    public bool green;
    public bool red;
    public prologue prologue;
    public PrologueTalkMgr PrologueTalkMgr;
    public GameObject YellowButton;
    public GameObject GreenButton;
    public GameObject RedButton;
    public GameObject YellowNote;
    public GameObject GreenNote;
    public GameObject RedNote;
    public GameObject Blur;
    public GameObject Before;
    public GameObject After;
    public PrologueTalkMgr talkMgr;
    public GameObject Panel;

    private bool firstYellow = true;
    private bool firstGreen = true;

    public void ButtonYellowDown() {
        ButtonDown();
        green = true;
        YellowNote.SetActive(true);
    }

    public void ButtonGreenDown() {
        ButtonDown();
        red = true;
        GreenNote.SetActive(true);
    }

    public void ButtonRedDown() {
        Before.SetActive(false);
        After.SetActive(true);
        StartCoroutine(prologue.PrologueMgr());
    }

    public void NoteYellowDown() {
        if (firstYellow) {
            firstYellow = false;
            prologue.Talk();
            StartCoroutine(DelayYellowNote());
        }
        else {
            YellowNote.SetActive(false);
            NoteDown();
        }
    }

    IEnumerator DelayYellowNote() {
        yield return new WaitUntil(() => PrologueTalkMgr.noteDisappear);
        PrologueTalkMgr.noteDisappear = false;
        YellowNote.SetActive(false);
        NoteDown();
        StartCoroutine(prologue.PrologueMgr());
    }

    public void NoteGreenDown() {
        if (firstGreen) {
            firstGreen = false;
            prologue.Talk();
            StartCoroutine(DelayGreenNote());
        }
        else {
            GreenNote.SetActive(false);
            NoteDown();
        }
    }

    IEnumerator DelayGreenNote() {
        yield return new WaitUntil(() => PrologueTalkMgr.noteDisappear);
        PrologueTalkMgr.noteDisappear = false;
        GreenNote.SetActive(false);
        NoteDown();
        StartCoroutine(prologue.PrologueMgr());
    }

    void ButtonDown() {
        Blur.SetActive(true);
        YellowButton.SetActive(false);
        GreenButton.SetActive(false);
        RedButton.SetActive(false);
    }

    void NoteDown() {
        Blur.SetActive(false);
        if (yellow) YellowButton.SetActive(true);
        if (green) GreenButton.SetActive(true);
        if (red) RedButton.SetActive(true);
    }
} 
