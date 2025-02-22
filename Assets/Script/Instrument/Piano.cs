using System.Collections;
using UnityEngine;

public class Piano : MonoBehaviour
{
    [Header("Audio Settings")]
    [Tooltip("순서대로 재생될 mp3 클립 3개")]
    public AudioClip[] pianoClips;
    public AudioSource audioSource; 

    private bool isPlayerNearby = false;
    private bool isPlaying = false;

    private void Start()
    {
        
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        if (audioSource == null)
        {
            Debug.LogError("Piano 오브젝트에 AudioSource 컴포넌트가 없습니다.");
        }
    }

    private void Update()
    {
       
        if (isPlayerNearby && !isPlaying && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(PlayPianoClips());
        }
    }

    private IEnumerator PlayPianoClips()
    {
        isPlaying = true;
        if (pianoClips != null && pianoClips.Length > 0)
        {
            for (int i = 0; i < pianoClips.Length; i++)
            {
                AudioClip clip = pianoClips[i];
                if (clip != null)
                {
                    audioSource.clip = clip;
                    audioSource.Play();
                    yield return new WaitForSeconds(clip.length);
                }
            }
        }
        isPlaying = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}
