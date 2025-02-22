using UnityEngine;
using UnityEngine.SceneManagement;

public class Stair1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어가 계단에 접근했습니다. Second 씬으로 이동합니다.");

            PlayerPrefs.DeleteKey("BookshelfHeart_SelectedContainerIndex");
            PlayerPrefs.DeleteKey("BookshelfHeart_SelectedBookIndex");
            PlayerPrefs.DeleteKey("BookshelfSpade_SelectedContainerIndex");
            PlayerPrefs.DeleteKey("BookshelfSpade_SelectedBookIndex");
            PlayerPrefs.DeleteKey("BookshelfDiamond_SelectedContainerIndex");
            PlayerPrefs.DeleteKey("BookshelfDiamond_SelectedBookIndex");
            PlayerPrefs.DeleteKey("BookshelfClover_SelectedContainerIndex");
            PlayerPrefs.DeleteKey("BookshelfClover_SelectedBookIndex");
            PlayerPrefs.DeleteKey("PreviousSceneName");

            SceneManager.LoadScene("Second");
        }
    }
}
