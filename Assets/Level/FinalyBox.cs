using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalyBox : MonoBehaviour
{
    [SerializeField] private GameObject Gplayer;
    [HideInInspector] public bool IsReady = true;
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.tag == "Player" && IsReady)
        {
            Gplayer.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(120, 0));
        }
        else if (!IsReady)
        {
            Gplayer.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
