using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobby : MonoBehaviour
{
    string gameVersion = "1";

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        Connect();
    }
    
    public void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }
}

