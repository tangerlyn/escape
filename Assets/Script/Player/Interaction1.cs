using UnityEngine;
using System.Collections.Generic;

public class DrawerInteraction : MonoBehaviour
{
    private bool isPlayerNearby = false;
    public List<GameObject> closedDrawerImages; // 닫힌 서랍 이미지 오브젝트 리스트
    public List<GameObject> openDrawerImages;   // 열린 서랍 이미지 오브젝트 리스트
    public List<GameObject> itemImages;          // 아이템 이미지 오브젝트 리스트

    private void Start()
    {
        SetDrawerState(true); // 시작할 때 모든 닫힌 서랍 보여주기
        SetItemVisibility(false); // 아이템 이미지를 비활성화
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F)) // F 키를 눌렀을 때
        {
            ToggleDrawer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("desk2"))
        {
            isPlayerNearby = true;
            Debug.Log("플레이어가 서랍에 가까이 왔습니다.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("desk2"))
        {
            isPlayerNearby = false;
            Debug.Log("플레이어가 서랍에서 멀어졌습니다.");
        }
    }

    private void ToggleDrawer()
    {
        if (closedDrawerImages[0].activeSelf) // 첫 번째 닫힌 이미지가 활성화되어 있을 경우
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
        SetDrawerState(false); // 열린 서랍 보이기
        SetItemVisibility(true); // 아이템 이미지 보이기
        Debug.Log("서랍이 열렸습니다!");
    }

    private void CloseDrawer()
    {
        SetDrawerState(true); // 닫힌 서랍 보이기
        SetItemVisibility(false); // 아이템 이미지 감추기
        Debug.Log("서랍이 닫혔습니다!");
    }

    private void SetDrawerState(bool isClosed)
    {
        // 닫힌 서랍 상태 설정
        foreach (var image in closedDrawerImages)
        {
            image.SetActive(isClosed);
        }

        // 열린 서랍 상태 설정
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
