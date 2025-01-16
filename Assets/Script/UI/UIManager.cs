using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject inventoryPanel;  

    public void SetInventoryVisibility(bool isVisible)
    {
        inventoryPanel.SetActive(isVisible); 
    }
}
