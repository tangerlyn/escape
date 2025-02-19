using UnityEngine;
using UnityEngine.SceneManagement;

public class Bookshelf : MonoBehaviour
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

        if (other.CompareTag("BookshelfDiamond"))
        {
            isPlayerInRange = true;
            sceneToLoad = "BookshelfDiamond"; // �ش� �� �̸�
        }
        else if (other.CompareTag("BookshelfClover"))
        {
            isPlayerInRange = true;
            sceneToLoad = "BookshelfClover"; // �ش� �� �̸�
        }
        else if (other.CompareTag("BookshelfHeart"))
        {
            isPlayerInRange = true;
            sceneToLoad = "BookshelfHeart"; // �ش� �� �̸�
        }
        else if (other.CompareTag("BookshelfSpade"))
        {
            isPlayerInRange = true;
            sceneToLoad = "BookshelfSpade"; // �ش� �� �̸�
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
