using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public static int step = 0;
    public static int language = 1;
    public int SetStep = 0;

    [SerializeField] GameObject doorOpen;
    [SerializeField] GameObject doorClose;
    // Start is called before the first frame update
    void Start()
    {
        step = SetStep;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DoorOpen()
    {
        doorOpen.SetActive(true);
        doorClose.SetActive(false);
    }

}
