using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneBookHighlighter : MonoBehaviour
{
    public GameObject[] bookContainers;

    void Start()
    {
        HighlightSelectedBook();
    }

    void HighlightSelectedBook()
    {
        string previousSceneName = PlayerPrefs.GetString("PreviousSceneName", "DefaultSceneName"); // 기본값 설정

        int selectedContainerIndex = PlayerPrefs.GetInt($"{previousSceneName}_SelectedContainerIndex", 0);
        int selectedBookIndex = PlayerPrefs.GetInt($"{previousSceneName}_SelectedBookIndex", 0);

        if (selectedContainerIndex < bookContainers.Length && selectedBookIndex < bookContainers[selectedContainerIndex].transform.childCount)
        {
            GameObject selectedBook = bookContainers[selectedContainerIndex].transform.GetChild(selectedBookIndex).gameObject;
            selectedBook.GetComponent<SpriteRenderer>().color = Color.black; // 하이라이트 효과
        }
    }
}
