using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Blow : Attack
{
    public override void Init(GameObject go)
    {
        base.Init(go);
    }

    // 기본 공격
    public override void BasicAttack(GameObject target = null, Table_Attack.Info attackInfo = null)
    {
        m_GOTarget = target;

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

        // 다음 공격 여부
        if (m_Charater._attackInfo.m_iNextNum != 0)
        {
            Table_Attack.Info m_Attack = null;
            Managers.Table.m_Attack.m_Dictionary.TryGetValue(m_Charater._attackInfo.m_iNextNum, out m_Attack);
            BasicAttack(m_GOTarget, m_Attack);
        }
    }
}
