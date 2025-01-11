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
            // 아이템을 획득할 수 있는 상태로 설정
            PickUp_Item player = collision.GetComponent<PickUp_Item>();
            player.canCollectItem = true;
            player.currentItem = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 플레이어가 아이템에서 멀어지면 획득 불가능 상태로 설정
            PickUp_Item player = collision.GetComponent<PickUp_Item>();
            player.canCollectItem = false;
            player.currentItem = null;
        }
    }
}
