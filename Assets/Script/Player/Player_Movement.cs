using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D rigid;
    private Animator anim;
    private float h;
    private float v;
    private bool isHorizonMove;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Move Value
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        // Check Button Down & Up
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        // Check Horizontal Move
        if (hDown)
        {
            isHorizonMove = true;
        }
        else if (vDown)
        {
            isHorizonMove = false;
        }
        else if (hUp || vUp)
        {
            isHorizonMove = h != 0;
        }

        // Animation
        if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            anim.SetBool("isChange", false);
        }
    }

    private void FixedUpdate()
    {
        // Move
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        Vector2 targetPosition = rigid.position + moveVec * Speed * Time.fixedDeltaTime;

        // 충돌 체크
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(targetPosition, 0.1f); // 작은 반경으로 충돌 체크
        bool canMove = true;

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Furniture")) // "furniture" 태그가 있는 오브젝트와 충돌하면 이동 불가
            {
                canMove = false;
                break;
            }
        }

        if (canMove)
        {
            rigid.MovePosition(targetPosition); // 이동
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("충돌 발생: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("ChessPiece"))
        {
            ChessPiece chessPiece = collision.gameObject.GetComponent<ChessPiece>();
            if (chessPiece != null)
            {
                chessPiece.Move(new Vector2(h, v)); // 플레이어 이동 방향으로 체스말 이동
            }
        }
    }

}
