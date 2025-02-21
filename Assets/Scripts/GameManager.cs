using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Player 1 is in GameScene");
        }
        else
        {
            Debug.Log("Player 2 is in EscapeScene");
        }
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Joined room: " + PhotonNetwork.CurrentRoom.Name);
    }
}
