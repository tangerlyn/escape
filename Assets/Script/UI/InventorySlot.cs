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

public void StoreItem(GameObject itemPrefab)
{
    RemoveItem();

    storedItem = Instantiate(itemPrefab, slotObj.transform);
    storedItem.transform.localScale = Vector3.one; 

    RectTransform itemRect = storedItem.GetComponent<RectTransform>();
    Image itemImage = storedItem.GetComponent<Image>();

    if (itemRect != null && itemImage != null)
    {
        itemRect.anchorMin = new Vector2(0.5f, 0.5f);
        itemRect.anchorMax = new Vector2(0.5f, 0.5f);
        itemRect.anchoredPosition = Vector2.zero;
        itemRect.sizeDelta = Vector2.zero; 

        AspectRatioFitter arf = storedItem.GetComponent<AspectRatioFitter>();
        if (arf == null)
        {
            arf = storedItem.AddComponent<AspectRatioFitter>();
        }
        arf.aspectMode = AspectRatioFitter.AspectMode.FitInParent;
        
        if (itemImage.sprite != null)
        {
            float aspect = itemImage.sprite.rect.width / itemImage.sprite.rect.height;
            arf.aspectRatio = aspect;
        }
    }
    
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
