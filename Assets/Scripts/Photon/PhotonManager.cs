using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public partial class PhotonManager : MonoBehaviourPunCallbacks
{
    public PhotonView PV;

    public void Init()
    {
        PhotonNetwork.GameVersion = "1.0.0";
        PhotonNetwork.SendRate = 20; // 통신속도
        PhotonNetwork.SerializationRate = 10; // 통신속도

        PhotonNetwork.ConnectUsingSettings(); //접속

        Debug.Log(" photon Connect ");
    }

    public void Start()
    {
        
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);

        Debug.Log(" photon OnDisconnectd = " + cause);
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        Debug.Log(" photon OnConnectedToMaster ");

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby() // 로비접속 성공
    {
        base.OnJoinedLobby();

        Debug.Log(" Photon Join Lobby ");
    }

    public void OnLobby() //나의 로비 조인
    {
        PhotonNetwork.IsMessageQueueRunning = true;

        Debug.Log(" photon OnLobby ");
    }

    public void Clear()
    {

    }
}
