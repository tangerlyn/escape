using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Staircase : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            
            if (currentSceneName == "GameScene")
            {
                Debug.Log("플레이어가 계단에 접근했습니다. GameScene에서 Second 씬으로 이동합니다.");

                PlayerPrefs.DeleteKey("BookshelfHeart_SelectedContainerIndex");
                PlayerPrefs.DeleteKey("BookshelfHeart_SelectedBookIndex");
                PlayerPrefs.DeleteKey("BookshelfSpade_SelectedContainerIndex");
                PlayerPrefs.DeleteKey("BookshelfSpade_SelectedBookIndex");
                PlayerPrefs.DeleteKey("BookshelfDiamond_SelectedContainerIndex");
                PlayerPrefs.DeleteKey("BookshelfDiamond_SelectedBookIndex");
                PlayerPrefs.DeleteKey("BookshelfClover_SelectedContainerIndex");
                PlayerPrefs.DeleteKey("BookshelfClover_SelectedBookIndex");
                PlayerPrefs.DeleteKey("PreviousSceneName");

                SceneManager.LoadScene("Second");
            }
            else if (currentSceneName == "Second")
            {
                Debug.Log("플레이어가 계단에 접근했습니다. Second 씬에서 floor3 씬으로 이동합니다.");
                SceneManager.LoadScene("floor3");
            }
            else if (currentSceneName == "floor3")
            {
                Debug.Log("플레이어가 계단에 접근했습니다. floor3 씬에서 Fourth 씬으로 이동합니다.");
                SceneManager.LoadScene("Fourth");
            }
            else if (currentSceneName == "Fourth")
            {
                Debug.Log("플레이어가 계단에 접근했습니다. Fourth 씬에서 End 씬으로 이동합니다.");
                // SceneTransitionManager의 PhotonView를 사용하여 모든 클라이언트에게 End 씬 로드를 요청
                if (SceneTransitionManager.Instance != null)
                {
                    SceneTransitionManager.Instance.photonView.RPC("RPC_LoadEndScene", RpcTarget.All);
                }
                else
                {
                    Debug.LogError("SceneTransitionManager 인스턴스를 찾을 수 없습니다.");
                }
            }
        }
    }
}
