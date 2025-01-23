using UnityEngine;
using UnityEngine.UI;
using Photon.Voice.Unity;
using TMPro;

public class MuteManager : MonoBehaviour
{
    private VoiceConnection voiceConnection;
    private bool isMuted = false;

    [SerializeField]
    private TextMeshProUGUI muteButtonText; // TextMeshPro 텍스트

    void Start()
    {
        // VoiceConnection 컴포넌트 찾기
        voiceConnection = FindObjectOfType<VoiceConnection>();
        if (voiceConnection == null)
        {
            Debug.LogError("VoiceConnection component not found in the scene.");
            return;
        }

        UpdateMuteButtonText(); // 초기 텍스트 설정
    }

    // 음소거 토글 메서드
    public void ToggleMute()
    {
        if (voiceConnection != null && voiceConnection.PrimaryRecorder != null)
        {
            isMuted = !isMuted; // 음소거 상태 토글
            voiceConnection.PrimaryRecorder.TransmitEnabled = !isMuted;

            Debug.Log(isMuted ? "Microphone muted." : "Microphone unmuted.");
            UpdateMuteButtonText(); // 상태 변경 시 텍스트 업데이트
        }
    }

    // 음소거 상태 반환
    public bool IsMuted()
    {
        return isMuted;
    }

    // UI 버튼 텍스트 업데이트
    private void UpdateMuteButtonText()
    {
        if (muteButtonText != null)
        {
            muteButtonText.text = isMuted ? "Unmute" : "Mute";
        }
    }
}
