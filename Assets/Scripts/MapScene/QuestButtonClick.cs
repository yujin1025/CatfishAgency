using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestButtonClick : MonoBehaviour
{

    public GameMgr gameMgr;
    public GameObject scanObject;

    public void StartDialog()
    {
        ObjData objData = scanObject.GetComponent<ObjData>();
        Debug.Log(scanObject.name);
        gameMgr.Action(scanObject, objData.id / 1000);
    }

}
