using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetIsAction : MonoBehaviour
{
    public GameMgr gameMgr;

    public void SetIsActionTrue() {
        gameMgr.isAction = true;
    }
    public void SetIsActionFalse() {
        gameMgr.isAction = false;
    }
    public void SetIsActionChange() {
        gameMgr.isAction = !gameMgr.isAction;
    }
}
