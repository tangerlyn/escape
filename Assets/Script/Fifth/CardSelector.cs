using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic; // List 사용을 위한 네임스페이스 추가

public class CardSelector : MonoBehaviour
{
    public List<GameObject> cardList; // 카드 오브젝트를 List로 저장
    private GameObject[,] cards; // 2D 배열로 카드 저장
    private int currentRow = 0;
    private int currentColumn = 0;
    private int rows = 2;
    private int columns = 3;

    void Start()
    {
        // List를 2D 배열로 변환
        cards = new GameObject[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                int index = i * columns + j;
                if (index < cardList.Count)
                {
                    cards[i, j] = cardList[index];
                }
                else
                {
                    cards[i, j] = null; // 카드가 없는 경우 null 할당
                }
            }
        }

        UpdateSelection();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveSelection(0, 1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveSelection(0, -1);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveSelection(-1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveSelection(1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            FlipCard();
        }
    }

    void MoveSelection(int rowDirection, int columnDirection)
    {
        // 현재 카드 상태 확인
        GameObject currentCard = cards[currentRow, currentColumn];
        Card cardScript = currentCard.GetComponent<Card>();

        // 방향 이동 전 카드가 뒷면이라면 앞면으로 뒤집기
        if (cardScript.IsFlipped())
        {
            cardScript.Flip(); // 앞면으로 뒤집기
        }

        currentRow += rowDirection;
        currentColumn += columnDirection;

        // 경계 체크
        if (currentRow < 0) currentRow = 0;
        if (currentRow >= rows) currentRow = rows - 1;
        if (currentColumn < 0) currentColumn = 0;
        if (currentColumn >= columns) currentColumn = columns - 1;

        UpdateSelection();
    }

    void UpdateSelection()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                GameObject card = cards[i, j];
                if (card != null) // null 체크 추가
                {
                    Card cardScript = card.GetComponent<Card>();
                    if (i == currentRow && j == currentColumn)
                    {
                        // 선택된 카드 하이라이트 (스케일 조정)
                        cardScript.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f); // 크기 증가
                    }
                    else
                    {
                        cardScript.transform.localScale = Vector3.one; // 원래 크기로 복구
                    }
                }
            }
        }
    }

    void FlipCard()
    {
        GameObject selectedCard = cards[currentRow, currentColumn];
        if (selectedCard != null) // null 체크 추가
        {
            Card cardScript = selectedCard.GetComponent<Card>();
            // 카드의 앞면과 뒷면 뒤집기
            cardScript.Flip();
        }
    }
}
