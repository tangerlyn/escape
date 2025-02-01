using UnityEngine;

public class AlwaysOnTop : MonoBehaviour
{
    public int topSortingOrder = 100;

    private SpriteRenderer[] spriteRenderers;

    void Start()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer sr in spriteRenderers)
        {
            sr.sortingOrder = topSortingOrder;
        }
    }
}
