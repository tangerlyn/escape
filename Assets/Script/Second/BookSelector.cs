using UnityEngine;
using UnityEngine.SceneManagement;

public class BookSelector : MonoBehaviour
{
    public GameObject[] bookContainers;
    private int currentContainerIndex = 0;
    private int currentBookIndex = 0;
    private int booksPerContainer = 18;

    void Start()
    {
        UpdateSelection();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            MoveSelection(1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            MoveSelection(-1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            MoveContainer(1);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            MoveContainer(-1);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            SelectBook();
        }
    }

    void MoveSelection(int direction)
    {
        if (direction > 0 && currentBookIndex >= booksPerContainer - 1)
        {
            currentBookIndex = 0;
        }
        else if (direction < 0 && currentBookIndex <= 0)
        {
            currentBookIndex = booksPerContainer - 1;
        }
        else
        {
            currentBookIndex += direction;
            if (currentBookIndex < 0) currentBookIndex = 0;
            if (currentBookIndex >= booksPerContainer) currentBookIndex = booksPerContainer - 1;
        }

        UpdateSelection();
    }

    void MoveContainer(int direction)
    {
        int newContainerIndex = currentContainerIndex + direction;
        if (newContainerIndex < 0) newContainerIndex = 0;
        if (newContainerIndex >= bookContainers.Length) newContainerIndex = bookContainers.Length - 1;

        currentContainerIndex = newContainerIndex;
        UpdateSelection();
    }

    void UpdateSelection()
    {
        for (int i = 0; i < bookContainers.Length; i++)
        {
            GameObject container = bookContainers[i];
            for (int j = 0; j < booksPerContainer; j++)
            {
                GameObject book = container.transform.GetChild(j).gameObject;

                if (i == currentContainerIndex && j == currentBookIndex)
                {
                    book.GetComponent<SpriteRenderer>().color = Color.red;
                }
                else
                {
                    book.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        }
    }

    void SelectBook()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        // 선택한 책의 정보를 저장 (씬 이름 포함)
        PlayerPrefs.SetInt($"{sceneName}_SelectedContainerIndex", currentContainerIndex);
        PlayerPrefs.SetInt($"{sceneName}_SelectedBookIndex", currentBookIndex);
        PlayerPrefs.SetString("PreviousSceneName", sceneName); // 이전 씬 이름 저장
        PlayerPrefs.Save();

        // GameScene으로 전환
        SceneManager.LoadScene("Second");
    }
}
