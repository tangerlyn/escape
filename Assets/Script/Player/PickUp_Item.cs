using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Item : MonoBehaviour
{
    public bool canCollectItem = false;  
    public Item currentItem; 

    void Update()
    {
        if (canCollectItem && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F)))
        {
            CollectItem(); 
        }
    }

    void CollectItem()
    {
        if (currentItem != null)
        {
            Inventory playerInventory = GetComponent<Inventory>();
            for (int i = 0; i < playerInventory.slots.Count; i++)
            {
                if (playerInventory.slots[i].isEmpty)
                {
                    playerInventory.slots[i].StoreItem(currentItem.gameObject);
                    Debug.Log(currentItem.itemName + " 아이템을 인벤토리에 추가했습니다.");
                    Destroy(currentItem.gameObject);  
                    currentItem = null;
                    canCollectItem = false; 
                    break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            currentItem = collision.GetComponent<Item>();  
            canCollectItem = true;  
            Debug.Log("E키를 눌러 " + currentItem.itemName + " 아이템을 획득하세요.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            canCollectItem = false; 
            currentItem = null;
            Debug.Log("아이템 영역을 벗어났습니다.");
        }
    }
}
