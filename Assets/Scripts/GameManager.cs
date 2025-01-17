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
        // MasterClient�� ��� Player 1���� �÷���
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Playing as Player 1 in GameScene");
        }
        else
        {
            PhotonNetwork.LoadLevel("EscapeScene");
        }

        // ���� ä�� �ʱ�ȭ
        InitializeVoiceChat();
    }

    private void InitializeVoiceChat()
    {
        if (voiceRecorder == null)
        {
            Debug.LogError("Recorder is not assigned!");
            return;
        }

        // ���� ä�� Ȱ��ȭ
        voiceRecorder.TransmitEnabled = true;
        voiceRecorder.DebugEchoMode = PhotonNetwork.IsMasterClient; // �ڱ� ��Ҹ� ������ ����
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
