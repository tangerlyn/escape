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
        }
    }

private void Start()
{
    playerMovement = FindObjectOfType<Player_Movement>(); 
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
        playerMovement.SetMovementEnabled(true);  
    }
}

    private void HandleSlotSelection()
    {
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

private void DeleteSelectedItem()
{
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
        if (!selectedSlot.isEmpty)
        {
            GameObject itemInSlot = selectedSlot.storedItem;
            if (itemInSlot != null)
            {
                Debug.Log("아이템을 손에 듭니다: " + itemInSlot.name);
                selectedSlot.isEmpty = true;
                Instantiate(itemInSlot, transform.position + Vector3.up, Quaternion.identity); 
                Destroy(selectedSlot.storedItem);
            }
        }
    }
}
