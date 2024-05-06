using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour
{
    [SerializeField]
    Image progressBar;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;

        //비동기방식으로 씬을 불러오는 도중에 다른 작업 가능
        AsyncOperation op = SceneManager.LoadSceneAsync("MapScene");
        op.allowSceneActivation = false; //씬을 90퍼까지 로드한 상태로 기다림

        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;

            timer += Time.deltaTime; 
            if (op.progress < 0.9f) 
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                if (progressBar.fillAmount >= op.progress) 
                { 
                    timer = 0f; 
                } 
            } 
            
            else 
            { 
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer); 
                if (progressBar.fillAmount == 1.0f) 
                { 
                    op.allowSceneActivation = true; 
                    yield break; 
                } 
            }
        }
    }

}
