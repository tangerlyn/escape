using UnityEngine;

public class ChessManager : MonoBehaviour
{
    public GameObject staircasePrefab;
    public Transform staircaseSpawnPoint;

    private GameObject staircaseInstance;

    public ChessPiece[] chessPieces; // ü�� �� �迭
    public Vector2[] firstTargetPositions; // ù ��° ��ǥ ��ġ
    public Vector2[] secondTargetPositions; // �� ��° ��ǥ ��ġ
    public float targetRadius = 0.1f; // ���� �� üũ�� ���� �ݰ�

    private int currentCheck = 0; // ���� üũ�ؾ� �� ��ġ �ε���

    void Start()
    {
        // ��� �������� �ν��Ͻ�ȭ�ϰ� ��Ȱ��ȭ�մϴ�.
        staircaseInstance = Instantiate(staircasePrefab, staircaseSpawnPoint.position, Quaternion.identity);
        staircaseInstance.SetActive(false); // ó���� ��Ȱ��ȭ
    }

    void Update()
    {
        // �� �����Ӹ��� ü�� ���� ��ġ�� üũ
        CheckChessPositions();
    }

    void CheckChessPositions()
    {
        bool allOnTarget = true;

        // �� ü�� ���� ��ġ�� Ȯ��
        for (int i = 0; i < chessPieces.Length; i++)
        {
            Vector2 currentPosition = chessPieces[i].transform.position;
            Vector2 targetPosition = (currentCheck == 0) ? firstTargetPositions[i] : secondTargetPositions[i];

            if (IsWithinTargetRange(currentPosition, targetPosition, targetRadius))
            {
                Debug.Log($"ü�� �� {i + 1}��(��) ��ġ {targetPosition}�� �����߽��ϴ�.");
            }
            else
            {
                allOnTarget = false;
            }
        }

        // ��� �������� �� ���� üũ�� �̵�
        if (allOnTarget)
        {
            currentCheck++;
            if (currentCheck >= 2) // �� ��° ��ġ�� �������� ���
            {
                SpawnStaircase();
            }
            else
            {
                Debug.Log("��� ü�� ���� ù ��° ��ǥ ��ġ�� �����߽��ϴ�. ���� ��ǥ ��ġ�� Ȯ���մϴ�.");
            }
        }
    }

    private bool IsWithinTargetRange(Vector2 currentPosition, Vector2 targetPosition, float radius)
    {
        return Vector2.Distance(currentPosition, targetPosition) <= radius;
    }

    private void SpawnStaircase()
    {
        if (staircaseInstance != null)
        {
            staircaseInstance.SetActive(true); // ����� Ȱ��ȭ
            Debug.Log("��� ü�� ���� �� ��° ��ǥ ��ġ�� �����߽��ϴ�. ����� �����Ǿ����ϴ�.");
        }
        else
        {
            Debug.LogError("��� �������̳� ���� ��ġ�� �������� �ʾҽ��ϴ�.");
        }
    }
}
