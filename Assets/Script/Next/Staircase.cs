using UnityEngine;
using UnityEngine.SceneManagement;

public class Staircase : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            
            if (currentSceneName == "GameScene")
            {
                Debug.Log("플레이어가 계단에 접근했습니다. floor1에서 floor2 씬으로 이동합니다.");
                SceneManager.LoadScene("Second");
            }
            else if (currentSceneName == "Second")
            {
                Debug.Log("플레이어가 계단에 접근했습니다. floor2에서 floor3 씬으로 이동합니다.");
                SceneManager.LoadScene("floor3");
            }
            else if (currentSceneName == "floor3")
            {
                Debug.Log("플레이어가 계단에 접근했습니다. floor3에서 floor4 씬으로 이동합니다.");
                SceneManager.LoadScene("Fourth");
            }
        }
    }
}
