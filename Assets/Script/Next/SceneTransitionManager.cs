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
    else if (Instance != this)
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
    
    [PunRPC]
    public void RPC_LoadMainMenuScene()
    {
        Debug.Log("모든 클라이언트에서 MainMenu 씬 로드");
        SceneManager.LoadScene("MainMenu");
    }
}
