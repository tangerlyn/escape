using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float Speed;

    Rigidbody2D rigid;
    float h;
    float v;
    bool isHorizonMove;
    bool canMove = true; 
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!canMove)
        {
            h = 0;
            v = 0;
            return;
        }

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        if (hDown || vUp)
        {
            isHorizonMove = true;
        }
        else if (vDown || hUp)
        {
            isHorizonMove = false;
        }
    }

    private void FixedUpdate()
    {
        if (!canMove)  
        {
            rigid.velocity = Vector2.zero;
            return;
        }

        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * Speed;
    }

    public void SetMovementEnabled(bool enabled)
    {
        canMove = enabled;  
    }
}
