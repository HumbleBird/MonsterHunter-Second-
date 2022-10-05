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
}
