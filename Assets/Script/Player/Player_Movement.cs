using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float Speed;
    public Transform handPosition;
    private Rigidbody2D rigid;
    private float h;
    private float v;
    private bool isHorizonMove;
    private bool canMove = true;
    public GameObject heldItem;

    public static int currentDropSortingOrder = 50;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (canMove && Input.GetKeyDown(KeyCode.R))
        {
            DropItem();
        }

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
            isHorizonMove = true;
        else if (vDown || hUp) 
            isHorizonMove = false;

        UpdateHeldItemPosition();

        if (canMove && Input.GetKeyDown(KeyCode.R))
        {
            DropItem();
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
            sr.sortingOrder = currentDropSortingOrder+150;
        }
        currentDropSortingOrder++;
        
        heldItem = null;
    }
}

}
