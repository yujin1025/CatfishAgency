using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActivate : MonoBehaviour
{
    public GameObject Target;

    private void Start()
    {
        if (Target.activeSelf == true)
            Target.SetActive(false);

        else Target.SetActive(true);
    }

}
