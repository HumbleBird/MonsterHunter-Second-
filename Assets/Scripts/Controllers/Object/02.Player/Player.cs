using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Charater
{
    public Table_Player.Info playerInfo { get; set; }

    public override void SetInfo(int id)
    {
        playerInfo = Managers.Table.m_Player.Get(id);
        statInfo = Managers.Table.m_Stat.Get(playerInfo.m_iStat);


    }
}
