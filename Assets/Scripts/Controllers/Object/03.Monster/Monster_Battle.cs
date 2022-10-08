using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static Define;

public partial class Monster : AI
{
    void AttackRandom()
    {
        //int rand = Random.Range(1, 2);
        //if (rand == 1)
        //    _attack.BasicAttack(101);
        //else if (rand == 2)
        //    _attack.BasicAttack(102);

        _attack.BasicAttack(101);

        // 공격 거리 계산 후 쫓을지 다시 공격할지

    }

    void OnHitEvent()
    {
        // 해당 타겟과의 사정 거리와 해당 애니메이션의 공격 거리를 계산해서 데미지를 넣을지 말지를 계산한다.


        if (_lockTarget != null)
        {
            Charater cl = _lockTarget.GetComponent<Charater>();
            // 쿨타임

            //cl.OnAttacked(gameObject);
            if (Hp > 0)
            {
                float distance = (_lockTarget.transform.position - transform.position).magnitude;
                if (distance <= attackInfo.m_fRange)
                {
                    State = CreatureState.Skill;
                }
                else
                    State = CreatureState.Move;
            }
            else
            {
                State = CreatureState.Idle;
            }
        }
        else
        {
            State = CreatureState.Idle;
        }
    }
}
