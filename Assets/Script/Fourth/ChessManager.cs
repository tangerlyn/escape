using UnityEngine;

public class ChessManager : MonoBehaviour
{
    public GameObject staircasePrefab;
    public Transform staircaseSpawnPoint;

    private GameObject staircaseInstance;

    public ChessPiece[] chessPieces; // 체스 말 배열
    public Vector2[] firstTargetPositions; // 첫 번째 목표 위치
    public Vector2[] secondTargetPositions; // 두 번째 목표 위치
    public float targetRadius = 0.1f; // 범위 내 체크를 위한 반경

    private int currentCheck = 0; // 현재 체크해야 할 위치 인덱스

    void Start()
    {
        // 계단 프리팹을 인스턴스화하고 비활성화합니다.
        staircaseInstance = Instantiate(staircasePrefab, staircaseSpawnPoint.position, Quaternion.identity);
        staircaseInstance.SetActive(false); // 처음에 비활성화
    }

    void Update()
    {
        // 매 프레임마다 체스 말의 위치를 체크
        CheckChessPositions();
    }

    void CheckChessPositions()
    {
        bool allOnTarget = true;

        // 각 체스 말의 위치를 확인
        for (int i = 0; i < chessPieces.Length; i++)
        {
            Vector2 currentPosition = chessPieces[i].transform.position;
            Vector2 targetPosition = (currentCheck == 0) ? firstTargetPositions[i] : secondTargetPositions[i];

            if (IsWithinTargetRange(currentPosition, targetPosition, targetRadius))
            {
                Debug.Log($"체스 말 {i + 1}이(가) 위치 {targetPosition}에 도착했습니다.");
            }
            else
            {
                allOnTarget = false;
            }
        }

        // 모두 도달했을 때 다음 체크로 이동
        if (allOnTarget)
        {
            currentCheck++;
            if (currentCheck >= 2) // 두 번째 위치에 도달했을 경우
            {
                SpawnStaircase();
            }
            else
            {
                Debug.Log("모든 체스 말이 첫 번째 목표 위치에 도달했습니다. 다음 목표 위치를 확인합니다.");
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
            staircaseInstance.SetActive(true); // 계단을 활성화
            Debug.Log("모든 체스 말이 두 번째 목표 위치에 도달했습니다. 계단이 생성되었습니다.");
        }
        else
        {
            Debug.LogError("계단 프리팹이나 스폰 위치가 지정되지 않았습니다.");
        }
    }
}
