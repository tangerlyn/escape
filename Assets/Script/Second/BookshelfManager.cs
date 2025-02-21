using UnityEngine;

public class BookshelfManager : MonoBehaviour
{
    public GameObject staircasePrefab;
    public Transform staircaseSpawnPoint;

    // ��� GameObject
    private GameObject staircaseInstance;

    // �� å�庰�� ������ �ε��� ��
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
        // ��� �������� �ν��Ͻ�ȭ�ϰ� ��Ȱ��ȭ�մϴ�.
        staircaseInstance = Instantiate(staircasePrefab, staircaseSpawnPoint.position, Quaternion.identity);
        staircaseInstance.SetActive(false); // ó���� ��Ȱ��ȭ

        // �� å�忡 ���� ���õ� �ε����� �����ɴϴ�.
        int selectedDiamondContainerIndex = PlayerPrefs.GetInt("BookshelfDiamond_SelectedContainerIndex", 0);
        int selectedDiamondBookIndex = PlayerPrefs.GetInt("BookshelfDiamond_SelectedBookIndex", 0);

        int selectedHeartContainerIndex = PlayerPrefs.GetInt("BookshelfHeart_SelectedContainerIndex", 0);
        int selectedHeartBookIndex = PlayerPrefs.GetInt("BookshelfHeart_SelectedBookIndex", 0);

        int selectedSpadeContainerIndex = PlayerPrefs.GetInt("BookshelfSpade_SelectedContainerIndex", 0);
        int selectedSpadeBookIndex = PlayerPrefs.GetInt("BookshelfSpade_SelectedBookIndex", 0);

        int selectedCloverContainerIndex = PlayerPrefs.GetInt("BookshelfClover_SelectedContainerIndex", 0);
        int selectedCloverBookIndex = PlayerPrefs.GetInt("BookshelfClover_SelectedBookIndex", 0);

        // ������ �ε��� ���� ��
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
        // �� å�庰�� ������ �ε��� ���� ��
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
            staircaseInstance.SetActive(true); // ����� Ȱ��ȭ
        }
        else
        {
            Debug.LogError("��� �������̳� ���� ��ġ�� �������� �ʾҽ��ϴ�.");
        }
    }
}
