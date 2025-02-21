using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject AboutInventoryUI;
    public List<InventorySlot> slots = new List<InventorySlot>();
    private bool isInventoryOpen = false;
    private int selectedSlotIndex = 0;
    public Color normalColor = Color.white;
    public Color selectedColor = Color.red;
    private Player_Movement playerMovement;
    private bool isItemZoomed = false;
    private InventorySlot zoomedSlot;

    private void Start()
    {
        playerMovement = FindObjectOfType<Player_Movement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ToggleInventory();
        }

        if (isInventoryOpen)
        {
            HandleSlotSelection();

            if (Input.GetKeyDown(KeyCode.Q))
            {
                DeleteSelectedItem();
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                EquipSelectedItem();
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                ToggleItemZoom();
            }
        }
    }

    private void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        inventoryUI.SetActive(isInventoryOpen);
        AboutInventoryUI.SetActive(isInventoryOpen);

        if (isInventoryOpen)
        {
            HighlightSlot(selectedSlotIndex);
            playerMovement.SetMovementEnabled(false);
        }
        else
        {
            if (isItemZoomed) ToggleItemZoom();
            playerMovement.SetMovementEnabled(true);
        }
    }

    private void HandleSlotSelection()
    {
        if (isItemZoomed) return;

        int previousSlotIndex = selectedSlotIndex;

        if (Input.GetKeyDown(KeyCode.W) && selectedSlotIndex >= 3) selectedSlotIndex -= 3;
        if (Input.GetKeyDown(KeyCode.S) && selectedSlotIndex < slots.Count - 3) selectedSlotIndex += 3;
        if (Input.GetKeyDown(KeyCode.A) && selectedSlotIndex % 3 != 0) selectedSlotIndex -= 1;
        if (Input.GetKeyDown(KeyCode.D) && selectedSlotIndex % 3 != 2) selectedSlotIndex += 1;

        if (previousSlotIndex != selectedSlotIndex)
        {
            HighlightSlot(selectedSlotIndex);
        }
    }

    private void HighlightSlot(int index)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            Image slotImage = slots[i].GetComponent<Image>();
            slotImage.color = i == index ? selectedColor : normalColor;
        }
    }

    private void ToggleItemZoom()
    {
        InventorySlot selectedSlot = slots[selectedSlotIndex];

        if (isItemZoomed)
        {
            RectTransform zoomedSlotRect = zoomedSlot.GetComponent<RectTransform>();
            Image zoomedSlotImage = zoomedSlot.GetComponent<Image>();

            zoomedSlotRect.sizeDelta = zoomedSlot.originalSlotSize;
            zoomedSlotRect.anchoredPosition = zoomedSlot.originalPosition;
            zoomedSlotImage.color = zoomedSlot.originalColor;

            if (zoomedSlot.slotObj.transform.childCount > 0)
            {
                RectTransform itemRect = zoomedSlot.slotObj.transform.GetChild(0).GetComponent<RectTransform>();
                itemRect.localScale = Vector3.one;
            }

            foreach (var slot in slots)
            {
                slot.gameObject.SetActive(true);
            }

            inventoryUI.GetComponent<GridLayoutGroup>().enabled = true;
            isItemZoomed = false;
            zoomedSlot = null;
        }
        else if (!selectedSlot.isEmpty)
        {
            zoomedSlot = selectedSlot;
            RectTransform zoomedSlotRect = zoomedSlot.GetComponent<RectTransform>();
            Image zoomedSlotImage = zoomedSlot.GetComponent<Image>();
            RectTransform slot4Rect = slots[4].GetComponent<RectTransform>();

            zoomedSlot.originalPosition = zoomedSlotRect.anchoredPosition;
            zoomedSlot.originalColor = zoomedSlotImage.color;

            foreach (var slot in slots)
            {
                if (slot != selectedSlot)
                {
                    slot.gameObject.SetActive(false);
                }
            }

            inventoryUI.GetComponent<GridLayoutGroup>().enabled = false;

            zoomedSlot.transform.SetParent(inventoryUI.transform);
            zoomedSlotRect.sizeDelta = new Vector2(300, 300);

            if (zoomedSlot.slotObj.transform.childCount > 0)
            {
                RectTransform itemRect = zoomedSlot.slotObj.transform.GetChild(0).GetComponent<RectTransform>();
                itemRect.localScale = new Vector3(2f, 2f, 2f);
            }

            float adjustedX = slot4Rect.anchoredPosition.x - 150f;
            float posY = slot4Rect.anchoredPosition.y;
            zoomedSlotRect.anchoredPosition = new Vector2(adjustedX, posY);

            zoomedSlotImage.color = Color.white;
            isItemZoomed = true;
        }
    }

    private void DeleteSelectedItem()
    {
        if (isItemZoomed) return;

        InventorySlot selectedSlot = slots[selectedSlotIndex];
        if (!selectedSlot.isEmpty)
        {
            selectedSlot.RemoveItem();
            Debug.Log("아이템을 삭제했습니다.");
        }
    }

    private void EquipSelectedItem()
    {
        InventorySlot selectedSlot = slots[selectedSlotIndex];
        if (!selectedSlot.isEmpty && selectedSlot.storedItem != null)
        {
            GameObject itemInSlot = selectedSlot.storedItem;

            if (playerMovement != null)
            {
                playerMovement.HoldItem(itemInSlot);
                selectedSlot.RemoveItem();
                Debug.Log("아이템을 손에 듭니다: " + itemInSlot.name);
            }
        }
    }
}
