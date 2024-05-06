using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public void OnClickNewGame()
    {
        DataController.Instance.OnClickNewGame();
    }

    public void OnClickLoadGame()
    {
        DataController.Instance.OnClickLoadGame();
    }
}
