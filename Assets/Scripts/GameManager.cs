using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using Photon.Voice.Unity;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private Recorder voiceRecorder;
    [SerializeField] private GameObject voiceUI;

    void Start()
    {
        // MasterClient일 경우 Player 1으로 플레이
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Playing as Player 1 in GameScene");
        }
        else
        {
            PhotonNetwork.LoadLevel("EscapeScene");
        }

        // 음성 채팅 초기화
        InitializeVoiceChat();
    }

    private void InitializeVoiceChat()
    {
        if (voiceRecorder == null)
        {
            Debug.LogError("Recorder is not assigned!");
            return;
        }

        // 음성 채팅 활성화
        voiceRecorder.TransmitEnabled = true;
        voiceRecorder.DebugEchoMode = PhotonNetwork.IsMasterClient; // 자기 목소리 들을지 여부
        Debug.Log("Voice Chat Initialized.");
    }

    public void ToggleMute(bool isMuted)
    {
        if (voiceRecorder != null)
        {
            voiceRecorder.TransmitEnabled = !isMuted;
        }
    }
}
