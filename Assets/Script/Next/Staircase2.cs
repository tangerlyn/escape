using UnityEngine;
using UnityEngine.SceneManagement;

public class Staircase2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어가 계단에 접근했습니다. Floor4 씬으로 이동합니다.");
            SceneManager.LoadScene("Fourth");  
        }
    }
}
