using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : Charater
{
    public Table_Player.Info playerInfo { get; set; }

    public GameObject _attackItem;

    public override void SetInfo(int id)
    {
        playerInfo = Managers.Table.m_Player.Get(id);
        statInfo = Managers.Table.m_Stat.Get(playerInfo.m_iStat);
        ChangeClass(playerInfo.m_sClass);
    }

    public void Attack(GameObject obj)
    {
        Managers.Battle.HitEvent(gameObject, (int)Atk, obj);
    }

    public override void HitEvent()
    {
        TrigerDetector _detectorItem = _attackItem.GetComponentInChildren<TrigerDetector>();

        _detectorItem.Set();
    }
}
