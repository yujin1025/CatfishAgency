using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPanel : MonoBehaviour
{
    public Text ScriptTxt;
    public Text textDialogue; //현재 대사 

    void Start()
    {
        ScriptTxt.text = "";

    }

    void Update()
    {
        ScriptTxt.text = textDialogue.text;
    }



}
