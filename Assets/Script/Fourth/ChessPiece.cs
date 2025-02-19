using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    public float moveDistance = 1f;
    public float minX = -1f; // ���� �ּ� X ��ǥ
    public float maxX = 1f;  // ���� �ִ� X ��ǥ
    public float minY = -1f; // ���� �ּ� Y ��ǥ
    public float maxY = 1f;  // ���� �ִ� Y ��ǥ

    public void Move(Vector2 direction)
    {
        // �밢�� �̵� ����: ���� �Ǵ� ���� ���⸸ ���
        if (Mathf.Abs(direction.x) > 0 && Mathf.Abs(direction.y) > 0)
        {
            return; // �밢�� �̵� �� �Լ� ����
        }

        // ��ǥ ��ġ ���
        Vector2 targetPosition = (Vector2)transform.position + direction.normalized * moveDistance;

        // �ٸ� ü�������� �浹 üũ
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

        // �̵� ���� üũ
        if (canMove && IsWithinBounds(targetPosition))
        {
            transform.position = targetPosition; // �̵�
        }
    }

    private bool IsWithinBounds(Vector2 position)
    {
        return position.x >= minX && position.x <= maxX && position.y >= minY && position.y <= maxY;
    }
}
