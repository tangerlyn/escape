using UnityEngine;
using UnityEngine.SceneManagement;

public class Easel : MonoBehaviour
{
    private bool isPlayerInRange = false;
    private string sceneToLoad; // �ε��� ���� �̸��� ������ ����

    private void Update()
    {
        // �÷��̾ ���� �ȿ� �ְ� F Ű�� ������ ��
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
            sceneToLoad = "Easel"; // �ش� �� �̸�
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
