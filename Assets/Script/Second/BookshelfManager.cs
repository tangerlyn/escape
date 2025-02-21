using UnityEngine;

public class BookshelfManager : MonoBehaviour
{
    public GameObject staircasePrefab;
    public Transform staircaseSpawnPoint;

    // 계단 GameObject
    private GameObject staircaseInstance;

    // 각 책장별로 지정된 인덱스 값
    private int heartContainerIndex = 0;    // BookshelfHeart
    private int heartBookIndex = 1;          // BookshelfHeart

    private int spadeContainerIndex = 0;     // BookshelfSpade
    private int spadeBookIndex = 16;          // BookshelfSpade

    private int diamondContainerIndex = 2; // BookshelfDiamond
    private int diamondBookIndex = 3;       // BookshelfDiamond

    private int cloverContainerIndex = 1;    // BookshelfClover
    private int cloverBookIndex = 6;         // BookshelfClover

    void Start()
    {
        // 계단 프리팹을 인스턴스화하고 비활성화합니다.
        staircaseInstance = Instantiate(staircasePrefab, staircaseSpawnPoint.position, Quaternion.identity);
        staircaseInstance.SetActive(false); // 처음에 비활성화

        // 각 책장에 대한 선택된 인덱스를 가져옵니다.
        int selectedDiamondContainerIndex = PlayerPrefs.GetInt("BookshelfDiamond_SelectedContainerIndex", 0);
        int selectedDiamondBookIndex = PlayerPrefs.GetInt("BookshelfDiamond_SelectedBookIndex", 0);

        int selectedHeartContainerIndex = PlayerPrefs.GetInt("BookshelfHeart_SelectedContainerIndex", 0);
        int selectedHeartBookIndex = PlayerPrefs.GetInt("BookshelfHeart_SelectedBookIndex", 0);

        int selectedSpadeContainerIndex = PlayerPrefs.GetInt("BookshelfSpade_SelectedContainerIndex", 0);
        int selectedSpadeBookIndex = PlayerPrefs.GetInt("BookshelfSpade_SelectedBookIndex", 0);

        int selectedCloverContainerIndex = PlayerPrefs.GetInt("BookshelfClover_SelectedContainerIndex", 0);
        int selectedCloverBookIndex = PlayerPrefs.GetInt("BookshelfClover_SelectedBookIndex", 0);

        // 지정된 인덱스 값과 비교
        CheckAllBookshelfSelection(selectedDiamondContainerIndex, selectedDiamondBookIndex,
                                   selectedHeartContainerIndex, selectedHeartBookIndex,
                                   selectedSpadeContainerIndex, selectedSpadeBookIndex,
                                   selectedCloverContainerIndex, selectedCloverBookIndex);
    }

    void CheckAllBookshelfSelection(int selectedDiamondContainerIndex, int selectedDiamondBookIndex,
                                     int selectedHeartContainerIndex, int selectedHeartBookIndex,
                                     int selectedSpadeContainerIndex, int selectedSpadeBookIndex,
                                     int selectedCloverContainerIndex, int selectedCloverBookIndex)
    {
        // 각 책장별로 지정된 인덱스 값과 비교
        if (selectedDiamondContainerIndex == diamondContainerIndex && selectedDiamondBookIndex == diamondBookIndex &&
            selectedHeartContainerIndex == heartContainerIndex && selectedHeartBookIndex == heartBookIndex &&
            selectedSpadeContainerIndex == spadeContainerIndex && selectedSpadeBookIndex == spadeBookIndex &&
            selectedCloverContainerIndex == cloverContainerIndex && selectedCloverBookIndex == cloverBookIndex)
        {
            SpawnStaircase();
        }
    }

    private void SpawnStaircase()
    {
        if (staircaseInstance != null)
        {
            staircaseInstance.SetActive(true); // 계단을 활성화
        }
        else
        {
            Debug.LogError("계단 프리팹이나 스폰 위치가 지정되지 않았습니다.");
        }
    }
}
