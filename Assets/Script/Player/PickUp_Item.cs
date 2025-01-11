using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Item : MonoBehaviour
{
    public bool canCollectItem = false;
    public Item currentItem;

    void Update()
    {
        if (canCollectItem && Input.GetKeyDown(KeyCode.E))
        {
            CollectItem();
        }
    }

    void CollectItem()
    {
        if (currentItem != null)
        {
            // 아이템을 획득하는 로직 (예: 인벤토리에 추가)
            Debug.Log("아이템 획득: " + currentItem.itemName);
            Destroy(currentItem.gameObject); // 아이템을 씬에서 제거
        }
    }
}
