using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject front; // ī�� �ո�
    public GameObject back;  // ī�� �޸�
    private bool isFlipped = false; // ī�尡 ���������� ����

    void Start()
    {
        ShowFront(); // �ʱ⿡�� �ո鸸 ���̵��� ����
    }

    public void Flip()
    {
        isFlipped = !isFlipped;
        if (isFlipped)
        {
            ShowBack();
            // ������ ī�� ũ�� ����
            back.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f); // �޸� ũ�� ����
        }
        else
        {
            ShowFront();
            // �ո� ī�� ũ�� ����
            front.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f); // �ո� ũ�� ����
        }
    }

    public bool IsFlipped() // ī�� ���� Ȯ�� �޼��� �߰�
    {
        return isFlipped;
    }

    private void ShowFront()
    {
        front.SetActive(true);
        back.SetActive(false);
    }

    private void ShowBack()
    {
        front.SetActive(false);
        back.SetActive(true);
    }
}
