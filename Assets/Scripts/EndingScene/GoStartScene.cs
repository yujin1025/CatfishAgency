using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoStartScene : MonoBehaviour
{
    public void GoingStart()
    {
        DataController.Instance.Save();
        SceneManager.LoadScene("StartScene");

    }
}
