using UnityEngine;

public class InstrumentInteraction : MonoBehaviour
{
    public AudioClip instrumentSound;

    private AudioSource audioSource;
    private bool playerInRange = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        
        audioSource.clip = instrumentSound;
        audioSource.volume = 1f;
        audioSource.loop = false;
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
                Debug.Log("악기 소리 재생됨.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("플레이어가 악기 범위에 진입했습니다.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("플레이어가 악기 범위를 벗어났습니다.");
        }
    }
}
