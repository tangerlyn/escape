using UnityEngine;

public class BookshelfClover : MonoBehaviour
{
    public GameObject[] bookContainers;

    void Start()
    {
        int selectedContainerIndex = PlayerPrefs.GetInt("BookshelfClover_SelectedContainerIndex", -1);
        int selectedBookIndex = PlayerPrefs.GetInt("BookshelfClover_SelectedBookIndex", -1);

        if (selectedContainerIndex >= 0 && selectedBookIndex >= 0)
        {
            HighlightBook(selectedContainerIndex, selectedBookIndex);
        }
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
