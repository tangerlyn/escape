using UnityEngine;
using UnityEngine.SceneManagement;

public class BookshelfController : MonoBehaviour
{
    private void Update()
    {
        // F 키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.F))
        {
            // 이전 씬으로 돌아가기
            SceneManager.LoadScene("Second"); // 원래 씬 이름
        }
    }
}
