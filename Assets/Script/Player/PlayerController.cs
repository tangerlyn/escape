using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static Vector3 lastPosition; // ������ ��ġ�� ������ ���� ����

    private void Start()
    {
        // ���� ���� �� ��ġ �ʱ�ȭ
        transform.position = lastPosition;
    }

    private void Update()
    {
        // �÷��̾� �̵� �ڵ� (��: WASD �Ǵ� ȭ��ǥ Ű)
        // �̵� �� ��ġ ����
        PlayerController.lastPosition = transform.position;
    }
}
