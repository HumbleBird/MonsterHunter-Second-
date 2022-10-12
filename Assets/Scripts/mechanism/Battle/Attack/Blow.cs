using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Blow : Attack
{
    // 기본 좌클릭 공격
    public override void BasicAttack(int id = 1)
    {
        _bNextAttackClick = false;
        Table_Attack.Info info = Managers.Table.m_Attack.Get(id);

        if(info == null)
        {
            Debug.LogError($"해당하는 {id}의 스킬이 없습니다.");
            return;
        }

        m_Player.Animator.SetBool(info.m_sAnimName, true);
        NextAttackCheck(info);
        return;
    }

    // 기본 좌클릭 공격
    public void BasicAttack2(int id = 1)
    {
        Table_Attack.Info info = Managers.Table.m_Attack.Get(id);

        if (info == null)
        {
            Debug.LogError($"해당하는 {id}의 스킬이 없습니다.");
            return;
        }

        m_Player.Animator.SetBool(info.m_sAnimName, true);
        NextAttackCheck(info);
        return;
    }

    public override void Kick()
    {
    }

    // 내려찍기
    public override void Skill()
    {
        
        
    }

    protected override void NextAttackCheck(Table_Attack.Info info)
    {
        AnimatorStateInfo Animinfo = m_Player.Animator.GetCurrentAnimatorStateInfo(0);

        if (Animinfo.IsName(info.m_sAnimName))
        {
            float curAnimationTime = Animinfo.normalizedTime;

            m_Player.Animator.SetBool(info.m_sAnimName, false);
            Debug.Log(m_Player.Animator.GetBool(info.m_sAnimName));
            if (curAnimationTime >= 0.7)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    if (info.m_iNextNum != 0)
                    {
                        BasicAttack(info.m_iNextNum);
                    }
                }
            }
        }
    }

}
