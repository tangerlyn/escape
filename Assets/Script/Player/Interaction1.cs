using UnityEngine;
using System.Collections.Generic;

public class DrawerInteraction : MonoBehaviour
{
    private bool isPlayerNearby = false;
    public List<GameObject> closedDrawerImages; // ���� ���� �̹��� ������Ʈ ����Ʈ
    public List<GameObject> openDrawerImages;   // ���� ���� �̹��� ������Ʈ ����Ʈ
    public List<GameObject> itemImages;          // ������ �̹��� ������Ʈ ����Ʈ

    private void Start()
    {
        SetDrawerState(true); // ������ �� ��� ���� ���� �����ֱ�
        SetItemVisibility(false); // ������ �̹����� ��Ȱ��ȭ
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F)) // F Ű�� ������ ��
        {
            ToggleDrawer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("desk2"))
        {
            isPlayerNearby = true;
            Debug.Log("�÷��̾ ������ ������ �Խ��ϴ�.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("desk2"))
        {
            isPlayerNearby = false;
            Debug.Log("�÷��̾ �������� �־������ϴ�.");
        }
    }

    private void ToggleDrawer()
    {
        if (closedDrawerImages[0].activeSelf) // ù ��° ���� �̹����� Ȱ��ȭ�Ǿ� ���� ���
        {
            OpenDrawer();
        }
        else
        {
            CloseDrawer();
        }
    }

    private void OpenDrawer()
    {
        SetDrawerState(false); // ���� ���� ���̱�
        SetItemVisibility(true); // ������ �̹��� ���̱�
        Debug.Log("������ ���Ƚ��ϴ�!");
    }

    private void CloseDrawer()
    {
        SetDrawerState(true); // ���� ���� ���̱�
        SetItemVisibility(false); // ������ �̹��� ���߱�
        Debug.Log("������ �������ϴ�!");
    }

    private void SetDrawerState(bool isClosed)
    {
        // ���� ���� ���� ����
        foreach (var image in closedDrawerImages)
        {
            image.SetActive(isClosed);
        }

        // ���� ���� ���� ����
        foreach (var image in openDrawerImages)
        {
            image.SetActive(!isClosed);
        }
    }

    private void SetItemVisibility(bool isVisible)
    {
        foreach (var item in itemImages)
        {
            item.SetActive(isVisible);
        }
    }
}
