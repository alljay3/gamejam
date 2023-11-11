using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public bool inputOn = true;
    [SerializeField] private float Speed = 1;
    private Vector2 _vectorMove;

    public void Update()
    {
        if (inputOn)
        {
            _vectorMove.x = Input.GetAxisRaw("Horizontal");
            _vectorMove.y = Input.GetAxisRaw("Vertical");
            gameObject.GetComponent<Rigidbody2D>().velocity = _vectorMove *= Speed; 
        }
    }
}
