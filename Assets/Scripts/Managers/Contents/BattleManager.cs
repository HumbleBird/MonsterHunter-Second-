﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Define;

public class BattleManager
{
    void CreatePlayer(int id)
    {
        Table_Player.Info pinfo = Managers.Table.m_Player.Get(id);

        if (pinfo == null)
        {
            Debug.LogError("해당하는 Id의 플레이어가 없습니다.");
            return;
        }

        GameObject go = Managers.Resource.Instantiate(pinfo.m_sPrefabPath);
        Managers.Object.Add(pinfo.m_nID, go);
        go.GetComponent<Charater>().SetInfo(pinfo.m_nID);
    }

    void CreateMonster(int id)
    {
        Table_Boss.Info binfo = Managers.Table.m_Boss.Get(id);

        if (binfo == null)
        {
            Debug.LogError("해당하는 Id의 보스가 없습니다.");
            return;
        }

        GameObject go = Managers.Resource.Instantiate(binfo.m_sPrefabPath);
        Managers.Object.Add(binfo.m_nID, go);
        go.GetComponent<Charater>().SetInfo(binfo.m_nID);
    }

    public void SpawnCharater(CharaterType type)
    {
        switch (type)
        {
            case CharaterType.Player:
                CreatePlayer(1);
                break;
            case CharaterType.Monster:

                break;
            case CharaterType.Boss:
                CreateMonster(101);
                break;
            default:
                break;
        }
    }
}
