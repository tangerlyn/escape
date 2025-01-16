using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public GameObject slotObj;  
    public bool isEmpty = true;  
    public GameObject storedItem;  

    private Image slotImage;  

    private RectTransform slotRectTransform;  
    private RectTransform itemRectTransform;  

    private Vector2 originalSlotSize = new Vector2(100f, 100f); 
    private Vector2 expandedSlotSize = new Vector2(300f, 300f);  
    private Vector2 originalItemSize; 

    private bool isExpanded = false;  

    private void Awake()
    {
        slotRectTransform = GetComponent<RectTransform>();
        if (storedItem != null)
        {
            itemRectTransform = storedItem.GetComponent<RectTransform>();
            originalItemSize = itemRectTransform.sizeDelta;  
        }
    }

    public void StoreItem(GameObject item)
    {
        storedItem = item;
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
