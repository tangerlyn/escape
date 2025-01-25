using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public GameObject slotObj;
    public bool isEmpty = true;
    public GameObject storedItem;
    public Vector2 originalSlotSize = new Vector2(100f, 100f);
    public Vector2 originalItemSize;
    public Vector2 originalPosition;
    public Color originalColor;

    public void StoreItem(GameObject item)
    {
        RemoveItem();
        storedItem = Instantiate(item, slotObj.transform);
        RectTransform itemRect = storedItem.GetComponent<RectTransform>();

        itemRect.anchorMin = Vector2.zero;
        itemRect.anchorMax = Vector2.one;
        itemRect.anchoredPosition = Vector2.zero;
        itemRect.sizeDelta = Vector2.zero;

        isEmpty = false;
    }

    public void RemoveItem()
    {
        if (slotObj.transform.childCount > 0)
        {
            for (int i = 0; i < slotObj.transform.childCount; i++)
            {
                GameObject child = slotObj.transform.GetChild(i).gameObject;
                Destroy(child);
            }
        }

        isEmpty = true;
        storedItem = null;
    }
}
