using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static Vector3 lastPosition; // 마지막 위치를 저장할 정적 변수

    private void Start()
    {
        // 게임 시작 시 위치 초기화
        transform.position = lastPosition;
    }

    private void Update()
    {
        // 플레이어 이동 코드 (예: WASD 또는 화살표 키)
        // 이동 후 위치 저장
        PlayerController.lastPosition = transform.position;
    }
}
