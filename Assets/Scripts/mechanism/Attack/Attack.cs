using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Attack : Strategy
{
    Blow blow; // 근접 (검사, 건투가 등)
    Range range; // 원거리 (거너, 마법사 등)
    GameObject m_Go = null; // 플레이어
    Charater m_Charater = null;
    GameObject m_GOTarget = null; // 타겟
    Charater m_TargetCharater = null;

    // TODO 쿨타임, 거리, 애니메이션 등 가져오기

    protected virtual void Init(GameObject go)
    {
        m_Charater = m_Charater.GetComponent<Charater>();
    }

    // 기본 공격
    public virtual void BasicAttack(GameObject target = null, Table_Attack.Info attackInfo = null)
    {
        m_GOTarget = target;

        float distance = (m_GOTarget.transform.position - m_Go.transform.position).magnitude;
        m_TargetCharater = m_GOTarget.GetComponent<Charater>();
        if (attackInfo != null)
            m_Charater._attackInfo = attackInfo;

        if (m_Charater._attackInfo.m_fRange < distance)
        {
            m_Charater._animator.Play(m_Charater._attackInfo.m_sAnimName);
            m_TargetCharater.OnAttacked(m_Go);
        }

        if(m_Charater._attackInfo.m_iNextNum != 0)
        {
            Table_Attack.Info m_Attack = null;
            Managers.Table.m_Attack.m_Dictionary.TryGetValue(m_Charater._attackInfo.m_iNextNum, out m_Attack);
            BasicAttack(m_GOTarget, m_Attack);
        }
    }

    public virtual void Skill()
    {

    }

    public virtual void BasicCombo()
    {

    }

    // 스킬 + 스킬, 스킬 + 기본 공격 혹은 이동
    public virtual void SkillCombo()
    {

    }

    public virtual void Kick()
    {
        
    }
}
