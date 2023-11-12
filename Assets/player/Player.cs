using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public bool inputOn = true;
    [SerializeField] private float Speed = 1;
    private Vector2 _vectorMove;
    [SerializeField] GameObject Bounse;
    private bool _moveRight = false;
    private bool _lastMoveRight = true;


    private void Start()
    {
    }

    public void Update()
    {
        if (inputOn)
        {
            _vectorMove.x = Input.GetAxisRaw("Horizontal");
            _vectorMove.y = Input.GetAxisRaw("Vertical");
            gameObject.GetComponent<Rigidbody2D>().velocity = _vectorMove * Speed;
            if (_vectorMove.x > 0)
            {
                _moveRight = true;
            }
            if (_vectorMove.x < 0)
            {
                _moveRight = false;
            }
            if (gameObject.GetComponent<Rigidbody2D>().velocity != Vector2.zero)
            {
                GetComponent<Animator>().Play("Run2");
            }
            else
                GetComponent<Animator>().Play("Hold");
        }


        if (_moveRight && !_lastMoveRight)
        {
            Debug.Log("loh");
            Bounse.transform.Rotate(new Vector3(0, 180, 0));
            _lastMoveRight = true;
        }
        if (!_moveRight && _lastMoveRight)
        {
            Bounse.transform.Rotate(new Vector3(0, 180, 0));
            _lastMoveRight = false;
        }
    }
}
