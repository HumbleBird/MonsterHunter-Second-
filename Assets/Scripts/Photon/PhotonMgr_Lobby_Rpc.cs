using UnityEngine;

using Photon.Pun;
using static Define;

public partial class PhotonManager : MonoBehaviourPunCallbacks
{
    [PunRPC]
    void LobbyRoomEntry(Team teamPlayer, string _strUserName)
    {
        // 나인지 아닌지 확인하기

    }

    [PunRPC]
    void StartInGame()
    {

    }
}
