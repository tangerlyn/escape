using System.Collections;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject slotItem;
    private bool canCollectItem = false;
    private Inventory playerInventory;
    
    private void Update()
    {
        if (canCollectItem && Input.GetKeyDown(KeyCode.E))
        {
            CollectItem(); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInventory = collision.GetComponent<Inventory>();
            canCollectItem = true;  
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canCollectItem = false;  
        }
    }

    private void CollectItem()
    {
        for (int i = 0; i < playerInventory.slots.Count; i++)
        {
            if (playerInventory.slots[i].isEmpty)
            {
                Instantiate(slotItem, playerInventory.slots[i].slotObj.transform.position, Quaternion.identity, playerInventory.slots[i].slotObj.transform);
                playerInventory.slots[i].isEmpty = false;
                Destroy(gameObject);  
                Debug.Log("아이템을 인벤토리에 추가했습니다.");
                canCollectItem = false;
                break;
            }
        }
    }
}
