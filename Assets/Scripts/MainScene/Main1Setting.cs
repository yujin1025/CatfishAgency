using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Main1Setting : MonoBehaviour
{
    public void Main1Change()
    {
        StartCoroutine(loadScene());
    }

    IEnumerator loadScene()
    {
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadScene("LoadingScene");
    }
}
