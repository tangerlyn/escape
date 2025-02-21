using UnityEngine;
using Photon.Pun;
using System.Collections;

public class EndSceneManager : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        // 마스터 클라이언트만 10초 후에 RPC를 호출합니다.
        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(LoadMainMenuAfterDelay());
        }
    }

    private IEnumerator LoadMainMenuAfterDelay()
    {
        yield return new WaitForSeconds(10f);
        Debug.Log("10초 경과 - 모든 클라이언트에게 MainMenu 씬 로드 요청");
        // SceneTransitionManager의 PhotonView를 통해 RPC 호출
        SceneTransitionManager.Instance.photonView.RPC("RPC_LoadMainMenuScene", RpcTarget.All);
    }
}
