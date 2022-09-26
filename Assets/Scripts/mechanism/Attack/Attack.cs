using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface class Attack : Strategy
{
    Blow s_blow; // 근접 (검사, 건투가 등)
    Range range; // 원거리 (거너, 마법사 등)

    protected GameObject m_Go = null; // 플레이어
    protected Charater m_Charater = null;
    protected GameObject m_GOTarget = null; // 타겟
    protected Charater m_TargetCharater = null;
    protected GameObject m_GOProjectile = null; // 투사체

    // TODO 쿨타임, 거리, 애니메이션 등 가져오기

    public override void Init(GameObject go)
    {
        m_Charater = m_Charater.GetComponent<Charater>();
    }

    // 기본 공격
    public virtual void BasicAttack(GameObject target = null, Table_Attack.Info attackInfo = null)
    {

    }

    public virtual void Skill()
    {

    }

    public virtual void Kick(GameObject target = null, Table_Attack.Info attackInfo = null)
    {
        float distance = (m_GOTarget.transform.position - m_Go.transform.position).magnitude;
        m_TargetCharater = m_GOTarget.GetComponent<Charater>();
        if (attackInfo != null)
            m_Charater._attackInfo = attackInfo;

        // 거리 계산
        if (m_Charater._attackInfo.m_fRange < distance)
        {
            m_Charater._animator.Play(m_Charater._attackInfo.m_sAnimName);
            m_TargetCharater.OnAttacked(m_Go);
        }
    }
}
