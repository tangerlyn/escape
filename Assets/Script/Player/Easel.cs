using UnityEngine;
using UnityEngine.SceneManagement;

public class Easel : MonoBehaviour
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

        if (other.CompareTag("Easel"))
        {
            isPlayerInRange = true;
            sceneToLoad = "Easel"; // 해당 씬 이름
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Easel"))
        {
            isPlayerInRange = false;
        } 
    }
}
