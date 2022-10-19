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
    protected MonoBehaviour _mono;

    public virtual void Init(MonoBehaviour mono)
    {
        m_Go = Managers.Object.Find(1);
        m_Player = m_Go.GetComponent<Player>();
        _mono = mono;
    }

    public abstract IEnumerator BasicAttack(int id = 1);
    public abstract void Skill();
    public virtual void Kick() { }

    public abstract void NextAttackCheck();
}
