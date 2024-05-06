using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class prologue : MonoBehaviour
{
    public GameObject[] arrayImage = new GameObject[8];
    public GameObject BlockTouch;
    public GameObject Panel;
    public GameObject ShowScript;
    public GameObject Button;
    private Button button;
    public int imageOrder = 0;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    private Button button1;
    private Button button2;
    private Button button3;
    public DontDestroySound Mainbgm;
    public PrologueTalkMgr PrologueTalkMgr;
    public MemoMgr MemoMgr;
    public int order = 0;
    private bool firstYellow = true;
    private bool firstGreen = true;



    void Start()
    {
        button = Button.GetComponent<Button>();
        button1 = Button1.GetComponent<Button>();
        button2 = Button2.GetComponent<Button>();
        button3 = Button3.GetComponent<Button>();
        DataController.Instance.MySaveData.QuestId = 10;
        button.onClick.AddListener(click);
        GameObject Tmp = GameObject.Find("MainBGM(DontDestroy)");
        if (Tmp) {
            Mainbgm = Tmp.GetComponent<DontDestroySound>();
            Mainbgm.SceneChange();
        }
        StartCoroutine(PrologueMgr());
    }
 
    void click()
    {
        StartCoroutine(fade_out(arrayImage[imageOrder]));
        StartCoroutine(fade_in(arrayImage[imageOrder+1]));
        imageOrder++;
    }

    public void PanelClick() {
        StartCoroutine(PrologueMgr());
    }

    public IEnumerator PrologueMgr () {
        switch(order) {
            case 0:
                StartCoroutine(fade_out(arrayImage[imageOrder]));
                StartCoroutine(fade_in(arrayImage[imageOrder+1]));
                imageOrder++;
                yield return new WaitForSeconds(1f);
                Panel.SetActive(true);
                ShowScript.SetActive(true);
                BlockTouch.SetActive(true);
                PrologueTalkMgr.KeepGoing();
                order++;
                break;
            case 1:
                Panel.SetActive(false);
                ShowScript.SetActive(false);
                BlockTouch.SetActive(false);
                StartCoroutine(fade_out(arrayImage[imageOrder]));
                StartCoroutine(fade_in(arrayImage[imageOrder+1]));
                imageOrder++;
                yield return new WaitForSeconds(1f);
                Panel.SetActive(true);
                ShowScript.SetActive(true);
                BlockTouch.SetActive(true);
                PrologueTalkMgr.KeepGoing();
                order++;
                break;
            case 2:
                Panel.SetActive(false);
                ShowScript.SetActive(false);
                BlockTouch.SetActive(false);
                StartCoroutine(fade_out(arrayImage[imageOrder]));
                StartCoroutine(fade_in(arrayImage[imageOrder+1]));
                imageOrder++;
                Button.SetActive(true);
                yield return new WaitUntil(() => !Button.activeSelf);
                yield return new WaitForSeconds(1f);
                Panel.SetActive(true);
                ShowScript.SetActive(true);
                BlockTouch.SetActive(true);
                PrologueTalkMgr.KeepGoing();
                order++;
                break;
            case 3:
                Panel.SetActive(false);
                ShowScript.SetActive(false);
                BlockTouch.SetActive(false);
                StartCoroutine(fade_out(arrayImage[imageOrder]));
                StartCoroutine(fade_in(arrayImage[imageOrder+1]));
                imageOrder++;
                yield return new WaitForSeconds(1f);
                Panel.SetActive(true);
                ShowScript.SetActive(true);
                BlockTouch.SetActive(true);
                PrologueTalkMgr.KeepGoing();
                order++;
                break;
            case 4:
                StartCoroutine(fade_in(Button1, 2f));
                Panel.SetActive(false);
                ShowScript.SetActive(false);
                BlockTouch.SetActive(false);
                break;
            case 5:
                StartCoroutine(fade_in(Button2, 2f));
                Panel.SetActive(false);
                ShowScript.SetActive(false);
                BlockTouch.SetActive(false);
                break;
            case 6:
                StartCoroutine(fade_in(Button3, 2f));
                Panel.SetActive(false);
                ShowScript.SetActive(false);
                BlockTouch.SetActive(false);
                break;
            case 7:
                yield return new WaitForSeconds(1f);
                Panel.SetActive(true);
                ShowScript.SetActive(true);
                BlockTouch.SetActive(true);
                PrologueTalkMgr.KeepGoing();
                order++;
                break;
            case 8:
                StartCoroutine(fade_out(arrayImage[imageOrder]));
                StartCoroutine(fade_in(arrayImage[imageOrder+1]));
                imageOrder++;
                yield return new WaitForSeconds(1f);
                SceneManager.LoadScene("MainScene");
                break;
        }
    }

    public void Talk() {
        Panel.SetActive(true);
        ShowScript.SetActive(true);
        BlockTouch.SetActive(true);
        PrologueTalkMgr.KeepGoing();
    }

    public void click1() {
        if (firstYellow) {
            order++;
            firstYellow = false;
        }
            MemoMgr.ButtonYellowDown();
            return;
    }

    public void click2() {
        if (firstGreen) {
            order++;
            firstGreen = false;
        }
            MemoMgr.ButtonGreenDown();
            return;
    }

    public void click3() {
        BlockTouch.SetActive(true);
        //MemoMgr.ButtonRedDown();
        arrayImage[imageOrder].SetActive(false);
        arrayImage[imageOrder+1].SetActive(true);
        imageOrder++;
        order++;
        StartCoroutine(PrologueMgr());
        return;
    }

    IEnumerator fade_in(GameObject image)
    {
        Color color = image.GetComponent<Image>().color;
        float alpha = 0.0f;

        image.SetActive(true);


        while (alpha < 1)
        {
            alpha += 0.03f;
            color.a = alpha;
            image.GetComponent<Image>().color = color;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator fade_in(GameObject image, float time)
    {
        Color color = image.GetComponent<Image>().color;
        float alpha = 0.0f;

        image.SetActive(true);


        while (alpha < time)
        {
            alpha += 0.03f;
            color.a = alpha;
            image.GetComponent<Image>().color = color;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator fade_out(GameObject image)
    {
        Color color = image.GetComponent<Image>().color;
        float alpha = 1.0f;

        while (alpha > 0)
        {
            alpha -= 0.03f;
            color.a = alpha;
            image.GetComponent<Image>().color = color;
            yield return new WaitForSeconds(0.01f);
        }

        image.SetActive(false);
    }
}