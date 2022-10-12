using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public partial class AI : Charater
{
    public void Attack()
    {
        if (target != null)
        {
            m_CaughtPlayer = false;
            Managers.Battle.HitEvent(gameObject, statInfo.m_fAtk, target);
        }
    }
}