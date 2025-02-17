using UnityEngine;

public class InstrumentInteraction : MonoBehaviour
{
    public AudioClip instrumentSound;
    public int instrumentID;  

    private AudioSource audioSource;
    private bool playerInRange = false;
    private Inventory inventory; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
        
        audioSource.clip = instrumentSound;
        audioSource.volume = 1f;
        audioSource.loop = false;

        inventory = FindObjectOfType<Inventory>();
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (inventory != null && inventory.inventoryUI.activeSelf)
            {
                Debug.Log("인벤토리 창이 열려있어 악기 소리 재생이 중지됩니다.");
                return;
            }

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
                Debug.Log("악기 소리 재생됨. ID: " + instrumentID);

                if (InstrumentManager.Instance != null)
                {
                    InstrumentManager.Instance.RegisterInstrument(instrumentID);
                }
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
