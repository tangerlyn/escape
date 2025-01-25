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

        if (hDown || vUp) isHorizonMove = true;
        else if (vDown || hUp) isHorizonMove = false;

        UpdateHeldItemPosition();
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
        if (heldItem != null)
        {
            Destroy(heldItem);
        }

        if (handPosition != null && itemPrefab != null)
        {
            heldItem = Instantiate(itemPrefab, handPosition);
            heldItem.transform.localPosition = Vector3.zero;
            heldItem.transform.localRotation = Quaternion.identity;
            heldItem.transform.localScale = Vector3.one * 0.25f;
        }
    }
}
