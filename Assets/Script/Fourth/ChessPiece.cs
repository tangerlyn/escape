using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    public float moveDistance = 1f;
    public float minX = -1f; // 맵의 최소 X 좌표
    public float maxX = 1f;  // 맵의 최대 X 좌표
    public float minY = -1f; // 맵의 최소 Y 좌표
    public float maxY = 1f;  // 맵의 최대 Y 좌표

    public void Move(Vector2 direction)
    {
        // 대각선 이동 제한: 수평 또는 수직 방향만 허용
        if (Mathf.Abs(direction.x) > 0 && Mathf.Abs(direction.y) > 0)
        {
            return; // 대각선 이동 시 함수 종료
        }

        // 목표 위치 계산
        Vector2 targetPosition = (Vector2)transform.position + direction.normalized * moveDistance;

        // 다른 체스말과의 충돌 체크
        Collider2D[] colliders = Physics2D.OverlapCircleAll(targetPosition, 0.1f);
        bool canMove = true;

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("ChessPiece"))
            {
                canMove = false;
                break;
            }
        }

        // 이동 범위 체크
        if (canMove && IsWithinBounds(targetPosition))
        {
            transform.position = targetPosition; // 이동
        }
    }

    private bool IsWithinBounds(Vector2 position)
    {
        return position.x >= minX && position.x <= maxX && position.y >= minY && position.y <= maxY;
    }
}
