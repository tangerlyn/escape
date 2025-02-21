using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject front; // 카드 앞면
    public GameObject back;  // 카드 뒷면
    private bool isFlipped = false; // 카드가 뒤집혔는지 여부

    void Start()
    {
        ShowFront(); // 초기에는 앞면만 보이도록 설정
    }

    public void Flip()
    {
        isFlipped = !isFlipped;
        if (isFlipped)
        {
            ShowBack();
            // 뒤집힌 카드 크기 조정
            back.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f); // 뒷면 크기 증가
        }
        else
        {
            ShowFront();
            // 앞면 카드 크기 조정
            front.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f); // 앞면 크기 증가
        }
    }

    public bool IsFlipped() // 카드 상태 확인 메서드 추가
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
