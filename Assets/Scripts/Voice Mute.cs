using UnityEngine;
using UnityEngine.UI;
using Photon.Voice.Unity;
using TMPro;

public class MuteManager : MonoBehaviour
{
    private VoiceConnection voiceConnection;
    private bool isMuted = false;

    [SerializeField]
    private TextMeshProUGUI muteButtonText; // TextMeshPro �ؽ�Ʈ

    void Start()
    {
        // VoiceConnection ������Ʈ ã��
        voiceConnection = FindObjectOfType<VoiceConnection>();
        if (voiceConnection == null)
        {
            Debug.LogError("VoiceConnection component not found in the scene.");
            return;
        }

        UpdateMuteButtonText(); // �ʱ� �ؽ�Ʈ ����
    }

    // ���Ұ� ��� �޼���
    public void ToggleMute()
    {
        if (voiceConnection != null && voiceConnection.PrimaryRecorder != null)
        {
            isMuted = !isMuted; // ���Ұ� ���� ���
            voiceConnection.PrimaryRecorder.TransmitEnabled = !isMuted;

            Debug.Log(isMuted ? "Microphone muted." : "Microphone unmuted.");
            UpdateMuteButtonText(); // ���� ���� �� �ؽ�Ʈ ������Ʈ
        }
    }

    // ���Ұ� ���� ��ȯ
    public bool IsMuted()
    {
        return isMuted;
    }

    // UI ��ư �ؽ�Ʈ ������Ʈ
    private void UpdateMuteButtonText()
    {
        if (muteButtonText != null)
        {
            muteButtonText.text = isMuted ? "Unmute" : "Mute";
        }
    }
}
