using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSetting : MonoBehaviour
{
    public GameObject FirstGuest_button;
    public GameManager GameManager;
    public int ID;

    public GameObject BlackPanel;

    private void Update() {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ID = GameManager.questID;
        if (GameManager.questID == 10) {
            FirstGuest_button.SetActive(true);
            StartCoroutine(fade_out(BlackPanel));
        }
        else {
            BlackPanel.SetActive(false);
        }
    }

    public void MainChange()
    {
        SceneManager.LoadScene("StoryScene");
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
