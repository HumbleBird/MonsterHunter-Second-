﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Attack 
{
    protected GameObject m_Go = null; // 플레이어
    protected Player m_Player = null;
    protected GameObject m_GOTarget = null; // 타겟
    protected Monster m_TargetMonster = null;

    protected GameObject m_GOProjectile = null; // 투사체

    public virtual void Init()
    {
        m_Go = Managers.Object.Find(1);
        m_Player = m_Go.GetComponent<Player>();
    }

    public abstract IEnumerator BasicAttack(int id = 1);
    public abstract void BasicAttack2(int id = 1);
    public abstract void Skill();
    public virtual void Kick() { }

    protected bool _bNextAttackClick = false;
    public abstract void NextAttackCheck();
}
