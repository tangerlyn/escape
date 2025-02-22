using System.Collections.Generic;
using UnityEngine;

public class InstrumentManager : MonoBehaviour
{
    public static InstrumentManager Instance;

    public int[] correctSequence;

    private List<int> playedSequence = new List<int>();

    public GameObject staircasePrefab;
    public Transform staircaseSpawnPoint;

    private bool puzzleSolved = false;
    private GameObject staircaseInstance; // 계단 인스턴스

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void RegisterInstrument(int instrumentID)
    {
        if (puzzleSolved)
            return;

        playedSequence.Add(instrumentID);
        int index = playedSequence.Count - 1;

        if (playedSequence[index] != correctSequence[index])
        {
            Debug.Log("틀린 악기를 연주했습니다. 순서 초기화.");
            playedSequence.Clear();
            return;
        }
        else
        {
            Debug.Log("올바른 악기 [" + instrumentID + "] 연주됨 (위치 " + index + ").");
        }

        if (playedSequence.Count == correctSequence.Length)
        {
            puzzleSolved = true;
            Debug.Log("정답 -> 계단이 나타납니다.");
            SpawnStaircase();
        }
    }

    private void SpawnStaircase()
    {
        Debug.Log("계단 생성");
        if (staircasePrefab != null && staircaseSpawnPoint != null)
        {
            staircaseInstance = Instantiate(staircasePrefab, staircaseSpawnPoint.position, Quaternion.identity);
            staircaseInstance.SetActive(true); // 계단 활성화
        }
        else
        {
            Debug.LogError("계단 프리팹이나 스폰 위치가 지정되지 않았습니다.");
        }
    }
}
