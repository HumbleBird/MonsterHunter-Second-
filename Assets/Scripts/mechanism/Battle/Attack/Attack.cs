using System;
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

    public float cooldownTime = 2f;

    public virtual void Init()
    {
        m_Go = Managers.Object.Find(1);
        m_Player = m_Go.GetComponent<Player>();
    }

    public abstract void BasicAttack(int id = 1);
    public abstract void Skill();
    public abstract void Kick();

    protected bool _bNextAttackClick = false;
    protected virtual void NextAttackCheck(Table_Attack.Info info)
    {

    }
}
