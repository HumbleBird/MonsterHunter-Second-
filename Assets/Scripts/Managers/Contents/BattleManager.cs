using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager
{
    // 배틀에 대한 모늗 것을 관리한다
    // 누가 무엇을 썼고, 어떤 버프를 썻는지?
    // 오브젝트 관리도 여기서 해준다.

    // TODO Charater에서 Adapter하기
    public virtual void HitEvent(GameObject attacker, int dmg, GameObject victim)
    {
        // 데미지 계산으로 체력 깍기
        // 해당 객체의 피격 애니메이션을
        // 피격자와 공격자의 UI 스탯 변화를

        Charater victimCharater = victim.GetComponent<Charater>();

        int damage = (int)Mathf.Max(0, dmg - victimCharater.Def);
        victimCharater.Hp -= damage;

        // TODO 애니메이션
        victimCharater.Animator.Play("Hit");

        if (victimCharater.Hp <= 0)
        {
            victimCharater.Hp = 0;
            victimCharater.State = Define.CreatureState.Dead;
        }

        
    }

    // 버프 주기(누가 누구에게 무슨 효과를)
}
