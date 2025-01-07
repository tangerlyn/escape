using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class MainMenuManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private Button createRoomButton;
    [SerializeField] private Button joinRoomButton;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject waitingRoomPanel;
    [SerializeField] private GameObject joinRoomPanel;
    [SerializeField] private TMP_Text roomCodeText;
    [SerializeField] private TMP_InputField roomCodeInput;
    [SerializeField] private Button enterRoomButton; 

    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        ConnectToServer();

        createRoomButton.onClick.AddListener(OnCreateRoomClick);
        joinRoomButton.onClick.AddListener(OnJoinRoomClick);
        enterRoomButton.onClick.AddListener(JoinRoomWithCode); 
    }

    private void ConnectToServer()
    {
        Debug.Log("Connecting to server...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master Server");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
    }

    private void OnCreateRoomClick()
    {
        string roomCode = GenerateRoomCode();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        
        Debug.Log($"Creating room with code: {roomCode}");
        PhotonNetwork.CreateRoom(roomCode, roomOptions);
        
        mainMenuPanel.SetActive(false);
        waitingRoomPanel.SetActive(true);
        roomCodeText.text = "Room Code: " + roomCode;
    }

    private void OnJoinRoomClick()
    {
        mainMenuPanel.SetActive(false);
        joinRoomPanel.SetActive(true);
    }

    private string GenerateRoomCode()
    {
        return Random.Range(100000, 999999).ToString();
    }

    public void JoinRoomWithCode()
    {
        string roomCode = roomCodeInput.text;
        Debug.Log($"Attempting to join room: {roomCode}");
        PhotonNetwork.JoinRoom(roomCode);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log($"Joined Room. Player count: {PhotonNetwork.CurrentRoom.PlayerCount}");
        
        if (!PhotonNetwork.IsMasterClient)
        {
            joinRoomPanel.SetActive(false);
            waitingRoomPanel.SetActive(true);
            roomCodeText.text = "Joined Room: " + PhotonNetwork.CurrentRoom.Name;
        }

        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            Debug.Log("두 명의 플레이어가 모두 참가했습니다. 게임을 시작합니다.");
            if (PhotonNetwork.IsMasterClient)
            {
                StartGame();
            }
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"Player Entered Room. Current count: {PhotonNetwork.CurrentRoom.PlayerCount}");
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                StartGame();
            }
        }
    }

    private void StartGame()
    {
        Debug.Log("Loading GameScene...");
        PhotonNetwork.LoadLevel("GameScene");
    }

    // 에러 처리 추가
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError($"Room creation failed: {message}");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError($"Room join failed: {message}");
    }
}