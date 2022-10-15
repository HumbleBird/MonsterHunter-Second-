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
    Coroutine co;

    // 기본 좌클릭 공격
    public override IEnumerator BasicAttack(int id = 1)
    {
        info = Managers.Table.m_Attack.Get(id);
        //m_Player.attackCollider.SetActive(true);

        if (info == null)
        {
            Debug.LogError($"해당하는 {id}의 스킬이 없습니다.");
            yield break;
        }

        m_Player.Animator.SetBool(info.m_sAnimName, true);

        while (true)
        {
            AnimatorStateInfo Animinfo = m_Player.Animator.GetCurrentAnimatorStateInfo(0);

            if (Animinfo.normalizedTime >= 0.7f && Animinfo.IsName(info.m_sAnimName))
            {
                m_Player.Animator.SetBool(info.m_sAnimName, false);
                if (Input.GetMouseButtonDown(0))
                {
                    //BasicAttack(info.m_iNextNum);
                    Debug.Log("!");
                }
                break;
            }
            yield return null;
        }

        m_Player._isNextCanAttack = true;
        m_Player.State = Define.CreatureState.Idle;
    }
    public override void BasicAttack2(int id = 1)
    {
        info = Managers.Table.m_Attack.Get(id);

        if (info == null)
        {
            Debug.LogError($"해당하는 {id}의 스킬이 없습니다.");
            return;
        }

        m_Player.Animator.SetBool(info.m_sAnimName, true);

        while (true)
        {
            AnimatorStateInfo Animinfo = m_Player.Animator.GetCurrentAnimatorStateInfo(0);

            if (Animinfo.normalizedTime >= 0.7f && Animinfo.IsName(info.m_sAnimName))
            {
                m_Player.Animator.SetBool(info.m_sAnimName, false);
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("!");
                    BasicAttack2(info.m_iNextNum);
                }
                break;
            }
        }

        m_Player._isNextCanAttack = true;
    }

    public override void NextAttackCheck()
    {
        throw new NotImplementedException();
    }

    public override void Skill() { }
}
