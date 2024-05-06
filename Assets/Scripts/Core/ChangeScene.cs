using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("MapScene");
    }

    public void SceneChange1()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void SceneChange2()
    {
        SceneManager.LoadScene("StoryScene");
    }

    public void SceneChange3()
    {
        SceneManager.LoadScene("PrologueScene");
    }

}
