using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Blow : IAttack
{
    protected GameObject m_Go = null; // 플레이어
    protected Charater m_Charater = null;
    protected GameObject m_GOTarget = null; // 타겟
    protected Charater m_TargetCharater = null;
    protected GameObject m_GOProjectile = null; // 투사체

    public void Init(GameObject go)
    {
        m_Go = go;
        m_Charater = m_Go.GetComponent<Charater>();

        m_GOTarget = m_Charater.target;
        m_TargetCharater = m_GOTarget.GetComponent<Charater>();
    }

    // 기본 공격
    public void BasicAttack()
    {
        _bNextAttackClick = false;
        m_Charater._animator.Play(m_Charater._attackInfo.m_sAnimName);

        HitCheck();
        NextAttackCheck();

        // 다음 공격 유무 여부, 클릭 시간 감지.
        if (m_Charater._attackInfo.m_iNextNum != 0 && _bNextAttackClick == true)
        {
            Table_Attack.Info m_Attack = null;
            Managers.Table.m_Attack.m_Dictionary.TryGetValue(m_Charater._attackInfo.m_iNextNum, out m_Attack);
            m_Charater._attackInfo = m_Attack;
            _bNextAttackClick = false;
            Debug.Log("다음 공격" + m_Charater._attackInfo.m_iNextNum);
            BasicAttack();
        }

        // TODO 1타로 변경
    }

    public void Kick()
    {
    }

    public void Skill()
    {
        throw new NotImplementedException();
    }

    public void HitCheck()
    {
        float distance = (m_GOTarget.transform.position - m_Go.transform.position).magnitude;

        // 거리 계산
        if (m_Charater._attackInfo.m_fRange < distance)
        {
            m_TargetCharater.OnAttacked(m_Go);
        }
    }

    bool _bNextAttackClick = false;
    void NextAttackCheck()
    {
        // 애니메이션 체크
        float curAnimationTime = m_Charater._animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if(curAnimationTime >= 0.8)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _bNextAttackClick = true;
                return;
            }
        }
    }
}
