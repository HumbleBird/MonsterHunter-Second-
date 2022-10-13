using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Blow : Attack
{
    Table_Attack.Info info = null;

    // 기본 좌클릭 공격
    public override void BasicAttack(int id = 1)
    {
        info = Managers.Table.m_Attack.Get(id);

        if (info == null)
        {
            Debug.LogError($"해당하는 {id}의 스킬이 없습니다.");
            return;
        }

        m_Player.Animator.SetBool(info.m_sAnimName, true);
    }

    public override IEnumerator  NextAttackCheck()
    {
        AnimatorStateInfo Animinfo = m_Player.Animator.GetCurrentAnimatorStateInfo(0);

        while (Animinfo.normalizedTime <= 1 && Animinfo.IsName(info.m_sAnimName)) // 해당 애니메이션이 진행중일때
        {
            if (info.m_iNextNum != 0 && Animinfo.normalizedTime > 0.7)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    m_Player.Animator.SetBool(info.m_sAnimName, false);
                    Debug.Log("b");
                    BasicAttack(info.m_iNextNum);
                }
                m_Player.Animator.SetBool(info.m_sAnimName, false);
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                m_Player.Animator.SetBool(info.m_sAnimName, false);
                Debug.Log("c");
            }

        }

        yield return new WaitForSeconds(0.5f);
        Debug.Log("d");
    }

    public override void Skill() { }
}
