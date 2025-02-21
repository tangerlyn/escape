using UnityEngine;

public class BookshelfSpade : MonoBehaviour
{
    public GameObject[] bookContainers;

    void Start()
    {
        int selectedContainerIndex = PlayerPrefs.GetInt("BookshelfSpade_SelectedContainerIndex", 0);
        int selectedBookIndex = PlayerPrefs.GetInt("BookshelfSpade_SelectedBookIndex", 0);
        HighlightBook(selectedContainerIndex, selectedBookIndex);
    }

    void HighlightBook(int containerIndex, int bookIndex)
    {
        if (containerIndex < bookContainers.Length && bookIndex < bookContainers[containerIndex].transform.childCount)
        {
            GameObject selectedBook = bookContainers[containerIndex].transform.GetChild(bookIndex).gameObject;
            selectedBook.GetComponent<SpriteRenderer>().color = Color.black; // 하이라이트 효과
        }
    }
}
