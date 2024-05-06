using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endingTest : MonoBehaviour
{
    [SerializeField]
    private endingDialog endingdialog01;
    [SerializeField]
    private endingDialog endingdialog02;
    [SerializeField]
    private endingDialog endingdialog03;
    [SerializeField]
    private endingDialog endingdialog04;
    [SerializeField]
    private endingDialog endingdialog05;
    [SerializeField]
    private endingDialog endingdialog06;


    public GameObject[] arrayImage = new GameObject[7];
    public GameObject Background;
    public GameObject Panel;
    public GameObject ShowScript;
    public GameObject GoStart;
    protected float fadeTime = 0.4f;
    private bool buttonActive = true;


    public void Ending()
    {
        if (buttonActive) {
            StartCoroutine(StartEnding());
            buttonActive = false;
        }
    }

    private IEnumerator StartEnding()
    {
        
        StartCoroutine(fade_in(arrayImage[0]));
        StartCoroutine(fade_out(Background));
        //yield return new WaitForSeconds(1f);
        //Background.SetActive(false);
        Panel.SetActive(true);
        ShowScript.SetActive(true);
        yield return new WaitUntil(() => endingdialog01.UpdateDialog()); //true가 될때까지
        Panel.SetActive(false);
        ShowScript.SetActive(false);

        StartCoroutine(fade_in(arrayImage[1]));
        StartCoroutine(fade_out(arrayImage[0]));
        yield return new WaitForSeconds(1f);
        Panel.SetActive(true);
        ShowScript.SetActive(true);
        yield return new WaitUntil(() => endingdialog02.UpdateDialog());
        Panel.SetActive(false);
        ShowScript.SetActive(false);

        StartCoroutine(fade_in(arrayImage[2]));
        StartCoroutine(fade_out(arrayImage[1]));
        yield return new WaitForSeconds(1f);
        Panel.SetActive(true);
        ShowScript.SetActive(true);
        yield return new WaitUntil(() => endingdialog03.UpdateDialog());
        Panel.SetActive(false);
        ShowScript.SetActive(false);

        StartCoroutine(fade_in(arrayImage[3]));
        StartCoroutine(fade_out(arrayImage[2]));
        yield return new WaitForSeconds(1f);
        Panel.SetActive(true);
        ShowScript.SetActive(true);
        yield return new WaitUntil(() => endingdialog04.UpdateDialog());
        Panel.SetActive(false);
        ShowScript.SetActive(false);

        StartCoroutine(fade_in(arrayImage[4]));
        StartCoroutine(fade_out(arrayImage[3]));
        yield return new WaitForSeconds(1f);
        Panel.SetActive(true);
        ShowScript.SetActive(true);
        yield return new WaitUntil(() => endingdialog05.UpdateDialog());
        Panel.SetActive(false);
        ShowScript.SetActive(false);

        StartCoroutine(fade_in(arrayImage[5]));
        StartCoroutine(fade_out(arrayImage[4]));
        yield return new WaitForSeconds(1f);
        Panel.SetActive(true);
        ShowScript.SetActive(true);
        yield return new WaitUntil(() => endingdialog06.UpdateDialog());
        Panel.SetActive(false);
        ShowScript.SetActive(false);

        StartCoroutine(fade_in(arrayImage[6]));
        StartCoroutine(fade_out(arrayImage[5]));
        yield return new WaitForSeconds(3f);
        GoStart.SetActive(true);
    }

    IEnumerator fade_in(GameObject image)
    {
        image.SetActive(true);

        float currTime = 0.0f;
        float t = 0.0f;

        while (t < 1)
        {
            currTime += Time.deltaTime;
            t = currTime / fadeTime;

            Color color = image.GetComponent<Image>().color;
            color.a = Mathf.Lerp(0, 1, t);
            image.GetComponent<Image>().color = color;

            yield return null;
        }

        yield return new WaitForSeconds(1f);
        Panel.SetActive(true);
        ShowScript.SetActive(true);
    }

    IEnumerator fade_out(GameObject image)
    {
        float currTime = 0.0f;
        float t = 0.0f;

        while (t < 1)
        {
            currTime += Time.deltaTime;
            t = currTime / fadeTime;

            Color color = image.GetComponent<Image>().color;
            color.a = Mathf.Lerp(1, 0, t);
            image.GetComponent<Image>().color = color;

            yield return null;
        }

        image.SetActive(false);
    }
}
