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
            // �������� ȹ���ϴ� ���� (��: �κ��丮�� �߰�)
            Debug.Log("������ ȹ��: " + currentItem.itemName);
            Destroy(currentItem.gameObject); // �������� ������ ����
        }
    }
}
