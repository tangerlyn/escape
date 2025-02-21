using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic; // List ����� ���� ���ӽ����̽� �߰�

public class CardSelector : MonoBehaviour
{
    public List<GameObject> cardList; // ī�� ������Ʈ�� List�� ����
    private GameObject[,] cards; // 2D �迭�� ī�� ����
    private int currentRow = 0;
    private int currentColumn = 0;
    private int rows = 2;
    private int columns = 3;

    void Start()
    {
        // List�� 2D �迭�� ��ȯ
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
                    cards[i, j] = null; // ī�尡 ���� ��� null �Ҵ�
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
        // ���� ī�� ���� Ȯ��
        GameObject currentCard = cards[currentRow, currentColumn];
        Card cardScript = currentCard.GetComponent<Card>();

        // ���� �̵� �� ī�尡 �޸��̶�� �ո����� ������
        if (cardScript.IsFlipped())
        {
            cardScript.Flip(); // �ո����� ������
        }

        currentRow += rowDirection;
        currentColumn += columnDirection;

        // ��� üũ
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
                if (card != null) // null üũ �߰�
                {
                    Card cardScript = card.GetComponent<Card>();
                    if (i == currentRow && j == currentColumn)
                    {
                        // ���õ� ī�� ���̶���Ʈ (������ ����)
                        cardScript.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f); // ũ�� ����
                    }
                    else
                    {
                        cardScript.transform.localScale = Vector3.one; // ���� ũ��� ����
                    }
                }
            }
        }
    }

    void FlipCard()
    {
        GameObject selectedCard = cards[currentRow, currentColumn];
        if (selectedCard != null) // null üũ �߰�
        {
            Card cardScript = selectedCard.GetComponent<Card>();
            // ī���� �ո�� �޸� ������
            cardScript.Flip();
        }
    }
}
