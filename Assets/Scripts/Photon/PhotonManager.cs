using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public PhotonView PV;

    private void Awake()
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

        Debug.Log(" photon OnDisconnectd ");

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby() // 로비접속 성공
    {
        base.OnJoinedLobby();

        Debug.Log(" Photon OnDisconnectd ");
    }

    public void OnLobby() //나의 로비 조인
    {
        PhotonNetwork.IsMessageQueueRunning = true;

        Debug.Log(" photon OnLobby ");
    }

    ///////////////Room
    public void CreateLobbyRoom(string _strRoomName = null) // 방 생성
    {
        if (null == _strRoomName)
            return;

        PhotonNetwork.CreateRoom(_strRoomName);

        Debug.Log("CreateLobbyRoom = " + _strRoomName);
    }

    // 랜덤으로 방 들어가기

    public void JoinLobbyRoom(string _strRoomName = null) // 방 생성
    {
        if (null == _strRoomName)
            return;

        PhotonNetwork.JoinRoom(_strRoomName);

        Debug.Log("JoinLobbyRoom = " + _strRoomName);
    }

    public void Leave(bool _bCom = true)
    {
        PhotonNetwork.LeaveRoom(_bCom);

        Debug.Log("LeaveRoom ");
    }

    // 방 만들고, 들어가고, 실패하고, 삭제하고, 업데이트하고, 관리하고 등등

    // 방 진입, ready 완료, 게임 시작
}
