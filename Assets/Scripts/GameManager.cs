using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

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
}