using UnityEngine;
using UnityEngine.SceneManagement;

public class BookshelfController : MonoBehaviour
{
    private void Update()
    {
        // F Ű�� ������ ��
        if (Input.GetKeyDown(KeyCode.F))
        {
            // ���� ������ ���ư���
            SceneManager.LoadScene("Second"); // ���� �� �̸�
        }
    }
}
