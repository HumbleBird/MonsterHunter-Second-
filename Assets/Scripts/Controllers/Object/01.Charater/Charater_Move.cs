using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public partial class Charater : Base
{
    // 해당 오브젝트에 Photon View와 Photon Transform View를 붙일 것
    #region PHOTON
    Vector3 m_vCurPos;
    Quaternion m_qCurRot;
    PhotonView PV;

    void PhotonDeadReckoning() // 데드레커닝
    {
        transform.position = Vector3.Lerp(transform.position, m_vCurPos, Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, m_qCurRot, Time.deltaTime);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // 로컬 플레이어의 위치 정보 전달
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            m_vCurPos = (Vector3)stream.ReceiveNext();
            m_qCurRot = (Quaternion)stream.ReceiveNext();
        }
    }
    #endregion
}
