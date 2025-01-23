using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Playing as Player 1 in GameScene");
        }
        else
        {
            PhotonNetwork.LoadLevel("EscapeScene");
        }
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Joined room: " + PhotonNetwork.CurrentRoom.Name);
    }
}
