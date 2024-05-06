using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkPanel : MonoBehaviour
{
    public GameObject Panel;

    public void SetPanel()
    {
        Panel.SetActive(false);
    }

    //Camera _mainCam = null;
    public GameMgr gameMgr;
    private GameObject scanObject;
    private GameMgr gamemgr;


    void Start()
    {
        scanObject = GameObject.Find("QuestButton (1)").GetComponent<QuestButton>().scanObject;
        gamemgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();
    }
    
    public void SettingPanel()
    {
        if (gameMgr.isFind) {
            gameMgr.PanelAfterFind();
            return;
        }
        Debug.Log(gameMgr.getButtonNumber());
        scanObject = GameObject.Find("QuestButton ("+ gameMgr.getButtonNumber() + ")").GetComponent<QuestButton>().scanObject;
        Debug.Log(scanObject.name);
        if(gamemgr.isAction == true)
        {
            gameMgr.Action(scanObject, -1);
        }
        else
        {
            Panel.SetActive(false);
        }
    }
}
