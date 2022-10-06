using System;
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

        m_GOTarget = m_Player.target;
        m_TargetMonster = m_GOTarget.GetComponent<Monster>();

        ClearAttackInfo();
    }

    public abstract void BasicAttack(int id = 100001);
    public abstract void Skill();
    public abstract void Kick();

    protected bool _bNextAttackClick = false;
    protected void NextAttackCheck()
    {
        // 애니메이션 체크
        float curAnimationTime = m_Player.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (curAnimationTime >= 0.8)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _bNextAttackClick = true;
                return;
            }
        }
    }

    protected void ClearAttackInfo()
    {


    }
}
