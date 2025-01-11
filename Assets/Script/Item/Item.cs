using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // �������� ȹ���� �� �ִ� ���·� ����
            PickUp_Item player = collision.GetComponent<PickUp_Item>();
            player.canCollectItem = true;
            player.currentItem = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // �÷��̾ �����ۿ��� �־����� ȹ�� �Ұ��� ���·� ����
            PickUp_Item player = collision.GetComponent<PickUp_Item>();
            player.canCollectItem = false;
            player.currentItem = null;
        }
    }
}
