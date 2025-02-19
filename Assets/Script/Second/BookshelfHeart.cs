using UnityEngine;

public class BookshelfHeart : MonoBehaviour
{
    public GameObject[] bookContainers;

    void Start()
    {
        int selectedContainerIndex = PlayerPrefs.GetInt("BookshelfHeart_SelectedContainerIndex", 0);
        int selectedBookIndex = PlayerPrefs.GetInt("BookshelfHeart_SelectedBookIndex", 0);
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
