using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Blow : MonoBehaviour, IAttack
{
    protected GameObject m_Go = null; // 플레이어
    protected Charater m_Charater = null;
    protected GameObject m_GOTarget = null; // 타겟
    protected Charater m_TargetCharater = null;
    protected GameObject m_GOProjectile = null; // 투사체

    public void SetInfo(GameObject go)
    {
        m_Go = gameObject;
        m_Charater = m_Go.GetComponent<Charater>();

        m_GOTarget = m_Charater.target;
        m_TargetCharater = m_GOTarget.GetComponent<Charater>();
    }


    // 기본 공격
    public void BasicAttack()
    {
        float distance = (m_GOTarget.transform.position - m_Go.transform.position).magnitude;

        // 거리 계산
        if (m_Charater._attackInfo.m_fRange < distance)
        {
            m_Charater._animator.Play(m_Charater._attackInfo.m_sAnimName);
            m_TargetCharater.OnAttacked(m_Go);
        }

        // 다음 공격 유무 여부, 클릭 시간 감지.
        if (m_Charater._attackInfo.m_iNextNum != 0)
        {
            Table_Attack.Info m_Attack = null;
            Managers.Table.m_Attack.m_Dictionary.TryGetValue(m_Charater._attackInfo.m_iNextNum, out m_Attack);
            m_Charater._attackInfo = m_Attack;
            this.BasicAttack();
        }
    }

    public void CheckClickTime()
    {
    }

    public void Kick()
    {
    }

    // 직접적으로 데미지를 주는 것은 각 애니메이션 별로 넣고. 여기서는 애니메이션과 다음 콤보를 넣는 걸로
}
