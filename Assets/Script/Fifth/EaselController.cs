using UnityEngine;
using UnityEngine.SceneManagement;

public class EaselController : MonoBehaviour
{
    private void Update()
    {
        // F Ű�� ������ ��
        if (Input.GetKeyDown(KeyCode.F))
        {
            // ���� ������ ���ư���
            SceneManager.LoadScene("EscapeScene"); // ���� �� �̸�
        }
    }
}
