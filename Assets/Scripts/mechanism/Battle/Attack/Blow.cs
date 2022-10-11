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

        // 애니메이션
        m_Player.Animator.Play(info.m_sAnimName);
        NextAttackCheck(info.m_sAnimName);

        // 다음 공격 유무 여부, 클릭 시간 감지.
        if (info.m_iNextNum != 0 && _bNextAttackClick == true)
        {
            BasicAttack(info.m_iNextNum);
        }
        return;
    }

    public override void Kick()
    {
    }

    // 내려찍기
    public override void Skill()
    {
        throw new NotImplementedException();
    }

}
