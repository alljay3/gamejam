using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Exit());
    }
    IEnumerator Exit()
    {
        yield return new WaitForSeconds(10);
        Application.Quit();
    }
}
