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

        // �浹 üũ
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(targetPosition, 0.1f); // ���� �ݰ����� �浹 üũ
        bool canMove = true;

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Furniture")) // "furniture" �±װ� �ִ� ������Ʈ�� �浹�ϸ� �̵� �Ұ�
            {
                canMove = false;
                break;
            }
        }

        if (canMove)
        {
            rigid.MovePosition(targetPosition); // �̵�
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("�浹 �߻�: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("ChessPiece"))
        {
            ChessPiece chessPiece = collision.gameObject.GetComponent<ChessPiece>();
            if (chessPiece != null)
            {
                chessPiece.Move(new Vector2(h, v)); // �÷��̾� �̵� �������� ü���� �̵�
            }
        }
    }

}
