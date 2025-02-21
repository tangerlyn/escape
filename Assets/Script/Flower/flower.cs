using UnityEngine;

public class Flower : MonoBehaviour
{
    [Header("드랍존 설정")]
    public Transform dropZone1;
    public Transform dropZone2;
    public Transform dropZone3;
    public float checkRadius = 0.5f; 

    [Header("정답 아이템 이름")]
    public string expectedItemName1 = "Item1";
    public string expectedItemName2 = "Item2";
    public string expectedItemName3 = "Item3";

    [Header("계단 생성 설정")]
    public GameObject staircasePrefab;        
    public Transform staircaseSpawnPoint;     

    [Header("레이어 설정")]
    public LayerMask itemLayer; 

    private bool staircaseSpawned = false;    

    void Update()
    {
        if (!staircaseSpawned && CheckPuzzleSolved())
        {
            SpawnStaircase();
        }
    }

    bool CheckPuzzleSolved()
    {
        bool zone1Correct = CheckDropZone(dropZone1, expectedItemName1);
        bool zone2Correct = CheckDropZone(dropZone2, expectedItemName2);
        bool zone3Correct = CheckDropZone(dropZone3, expectedItemName3);

        return zone1Correct && zone2Correct && zone3Correct;
    }

    bool CheckDropZone(Transform zone, string expectedName)
    {
        Collider2D hit = Physics2D.OverlapCircle(zone.position, checkRadius, itemLayer);
        if (hit != null)
        {
            if (hit.transform.parent != null)
                return false;

            Item itemScript = hit.GetComponent<Item>();
            if (itemScript != null)
            {
                return itemScript.itemName.Equals(expectedName);
            }
        }
        return false;
    }

    void SpawnStaircase()
    {
        if (staircasePrefab != null && staircaseSpawnPoint != null)
        {
            Instantiate(staircasePrefab, staircaseSpawnPoint.position, Quaternion.identity);
            staircaseSpawned = true;
            Debug.Log("정답 아이템 배치 완료! 계단 생성.");
        }
        else
        {
            Debug.LogWarning("staircasePrefab 또는 staircaseSpawnPoint가 지정되지 않았습니다.");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        if (dropZone1 != null)
            Gizmos.DrawWireSphere(dropZone1.position, checkRadius);
        if (dropZone2 != null)
            Gizmos.DrawWireSphere(dropZone2.position, checkRadius);
        if (dropZone3 != null)
            Gizmos.DrawWireSphere(dropZone3.position, checkRadius);
    }
}
