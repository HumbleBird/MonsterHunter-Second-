﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Blow : Attack
{
    Table_Attack.Info info = null;
    Coroutine _co;

    // 기본 좌클릭 공격
    public override IEnumerator BasicAttack(int id = 1)
    {
        info = Managers.Table.m_Attack.Get(id);

        if (info == null)
        {
            Debug.LogError($"해당하는 {id}의 스킬이 없습니다.");
            yield break;
        }

        m_cGo.Animator.SetBool(info.m_sAnimName, true);

        while (true)
        {
            AnimatorStateInfo Animinfo = m_cGo.Animator.GetCurrentAnimatorStateInfo(0);

            if (Animinfo.normalizedTime >= 0.7f && Animinfo.IsName(info.m_sAnimName))
            {
                m_cGo.Animator.SetBool(info.m_sAnimName, false);
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("2타 3타 공격 중...");
                    //yield return _mono.StartCoroutine(BasicAttack(info.m_iNextNum));
                }
                break;
            }
            yield return null;
        }

        m_cGo._isNextCanAttack = true;
        m_cGo.State = Define.CreatureState.Idle;
    }

    public override void NextAttackCheck()
    {

    }

    public override void Skill() { }
}
