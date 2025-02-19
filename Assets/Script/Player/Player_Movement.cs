using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D rigid;
    private Animator anim;
    private float h;
    private float v;
    private bool isHorizonMove;

    public Transform handPosition;
    private bool canMove = true;
    public GameObject heldItem;

    public static int currentDropSortingOrder = 50;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (canMove && Input.GetKeyDown(KeyCode.R))
        {
            DropItem();
        }

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

        UpdateHeldItemPosition();

        if (canMove && Input.GetKeyDown(KeyCode.R))
        {
            DropItem();
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

    private void UpdateHeldItemPosition()
    {
        if (heldItem != null)
        {
            heldItem.transform.position = handPosition.position;
        }
    }

    public void SetMovementEnabled(bool enabled)
    {
        canMove = enabled;
    }

    public void HoldItem(GameObject itemPrefab)
    {
        Inventory playerInventory = FindObjectOfType<Inventory>();

        if (heldItem != null)
        {
            for (int i = 0; i < playerInventory.slots.Count; i++)
            {
                if (playerInventory.slots[i].isEmpty)
                {
                    playerInventory.slots[i].StoreItem(heldItem);
                    break;
                }
            }
            Destroy(heldItem);
            heldItem = null;
        }

        if (handPosition != null && itemPrefab != null)
        {
            heldItem = Instantiate(itemPrefab, handPosition);
            heldItem.transform.localPosition = Vector3.zero;
            heldItem.transform.localRotation = Quaternion.identity;

            heldItem.transform.localScale = Vector3.one * 0.5f;

            SpriteRenderer[] itemRenderers = heldItem.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer sr in itemRenderers)
            {
                sr.sortingOrder = 101;
            }
        }
    }

    public void DropItem()
    {
        if (heldItem != null)
        {
            // 캐릭터 위치를 기준으로 드랍
            Vector3 dropPosition = transform.position;
            heldItem.transform.SetParent(null);
            heldItem.transform.position = dropPosition;
            heldItem.transform.localScale = Vector3.one;

            heldItem.tag = "Item";

            Collider2D col = heldItem.GetComponent<Collider2D>();
            if (col == null)
            {
                BoxCollider2D boxCol = heldItem.AddComponent<BoxCollider2D>();
                boxCol.isTrigger = true;
            }
            else
            {
                col.enabled = true;
            }

            Item itemScript = heldItem.GetComponent<Item>();
            if (itemScript != null)
            {
                itemScript.enabled = true;
            }

            PickUp_Item pickupScript = heldItem.GetComponent<PickUp_Item>();
            if (pickupScript != null)
            {
                pickupScript.enabled = true;
            }
            else
            {
                heldItem.AddComponent<Item>();
                heldItem.AddComponent<PickUp>();
            }

            SpriteRenderer[] dropRenderers = heldItem.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer sr in dropRenderers)
            {
                sr.sortingOrder = currentDropSortingOrder + 150;
            }
            currentDropSortingOrder++;

            heldItem = null;
        }
    }
}
