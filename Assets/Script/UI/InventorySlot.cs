using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public GameObject slotObj;
    public bool isEmpty = true;
    public GameObject storedItem;

    public Vector2 originalSlotSize = new Vector2(100f, 100f);
    public Vector2 originalItemSize;
    public Vector2 originalPosition;
    public Color originalColor; 

    private void Awake()
    {
        RectTransform slotRectTransform = GetComponent<RectTransform>();
        Image slotImage = GetComponent<Image>();
        originalColor = slotImage.color; 

        if (storedItem != null)
        {
            RectTransform itemRect = storedItem.GetComponent<RectTransform>();
            originalItemSize = itemRect.sizeDelta;
        }
    }

    public void StoreItem(GameObject item)
    {
        storedItem = item;
        isEmpty = false;

        RectTransform itemRect = item.GetComponent<RectTransform>();
        originalItemSize = itemRect.sizeDelta; 
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
