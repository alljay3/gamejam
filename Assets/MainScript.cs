using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public static int step = 0;
    public static int language = 0;

    [SerializeField] GameObject doorOpen;
    [SerializeField] GameObject doorClose;
    // Start is called before the first frame update
    void Start()
    {
        
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
