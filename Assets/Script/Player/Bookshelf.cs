using UnityEngine;
using UnityEngine.SceneManagement;

public class Bookshelf : MonoBehaviour
{
    private bool isPlayerInRange = false;
    private string sceneToLoad; // 로드할 씬의 이름을 저장할 변수

    private void Update()
    {
        // 플레이어가 범위 안에 있고 F 키를 눌렀을 때
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Entered: {other.name}");

        if (other.CompareTag("BookshelfDiamond"))
        {
            isPlayerInRange = true;
            sceneToLoad = "BookshelfDiamond"; // 해당 씬 이름
        }
        else if (other.CompareTag("BookshelfClover"))
        {
            isPlayerInRange = true;
            sceneToLoad = "BookshelfClover"; // 해당 씬 이름
        }
        else if (other.CompareTag("BookshelfHeart"))
        {
            isPlayerInRange = true;
            sceneToLoad = "BookshelfHeart"; // 해당 씬 이름
        }
        else if (other.CompareTag("BookshelfSpade"))
        {
            isPlayerInRange = true;
            sceneToLoad = "BookshelfSpade"; // 해당 씬 이름
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("BookshelfDiamond"))
        {
            isPlayerInRange = false;
        }
        else if (other.CompareTag("BookshelfClover"))
        {
            isPlayerInRange = false;
        }
        else if (other.CompareTag("BookshelfHeart"))
        {
            isPlayerInRange = false;
        }
        else if (other.CompareTag("BookshelfSpade"))
        {
            isPlayerInRange = false;
        }
    }
}
