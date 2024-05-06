using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    public AudioSource DoorOpen;
    public AudioSource DoorClose;
    public AudioSource Ring;

    public void OpenandClose() {
        Open();
        Invoke("Close", 1.3f);
    }

    public void Open() {
        DoorOpen.Play();
        Ring.Play();
    }

    public void Close() {
        DoorClose.Play();
        Ring.Play();
    }
}
