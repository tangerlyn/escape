using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviourPun
{
    public static SceneTransitionManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [PunRPC]
    public void RPC_LoadEndScene()
    {
        Debug.Log("모든 클라이언트에서 End 씬 로드");
        SceneManager.LoadScene("End");
    }
}
