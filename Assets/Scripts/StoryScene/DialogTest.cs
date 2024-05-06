using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogTest : MonoBehaviour
{
    
	[SerializeField]
	private DialogSystem dialogSystem01;
	[SerializeField]
	private DialogSystem dialogSystem02;
    [SerializeField]
    private DialogSystem dialogSystem03;
    [SerializeField]
    private DialogSystem dialogSystem04;
    [SerializeField]
    private DialogSystem dialogSystem05;

    public GameObject[] imgs;


    void Start()
    {
        StartCoroutine(Dialog());
    }

	private IEnumerator Dialog()
	{
       
        if (GameManager.instance.questID == 10)
        {
            for(int i=0;i<5; i++)
            {
                imgs[i].SetActive(false);
            }
            imgs[0].SetActive(true);

            // 첫 번째 대사 분기 시작
            yield return new WaitUntil(() => dialogSystem01.UpdateDialog()); //true가 될때까지
            Debug.Log("끝1");
            DataController.Instance.MySaveData.stageNum[0] = true;
            SceneManager.LoadScene("MainScene1");
        }
		

        else if (GameManager.instance.questID == 20)
        {
            for (int i = 0; i < 5; i++)
            {
                imgs[i].SetActive(false);
            }
            imgs[1].SetActive(true);

            // 두 번째 대사 분기 시작
            yield return new WaitUntil(() => dialogSystem02.UpdateDialog());
            Debug.Log("끝2");
            DataController.Instance.MySaveData.stageNum[2] = true;
            SceneManager.LoadScene("MainScene1");
        }

        else if (GameManager.instance.questID == 30)
        {
            for (int i = 0; i < 5; i++)
            {
                imgs[i].SetActive(false);
            }
            imgs[2].SetActive(true);

            yield return new WaitUntil(() => dialogSystem03.UpdateDialog());
            Debug.Log("끝3");
            DataController.Instance.MySaveData.stageNum[4] = true;
            SceneManager.LoadScene("MainScene1");
        }

        else if (GameManager.instance.questID == 40)
        {
            for (int i = 0; i < 5; i++)
            {
                imgs[i].SetActive(false);
            }
            imgs[3].SetActive(true);

            yield return new WaitUntil(() => dialogSystem04.UpdateDialog());
            Debug.Log("끝4");
            DataController.Instance.MySaveData.stageNum[6] = true;
            SceneManager.LoadScene("MainScene1");
        }

        else if (GameManager.instance.questID == 50)
        {
            for (int i = 0; i < 5; i++)
            {
                imgs[i].SetActive(false);
            }
            imgs[4].SetActive(true);

            yield return new WaitUntil(() => dialogSystem05.UpdateDialog());
            Debug.Log("끝5");
            DataController.Instance.MySaveData.stageNum[8] = true;
            SceneManager.LoadScene("MainScene1");
        }
    }
}
