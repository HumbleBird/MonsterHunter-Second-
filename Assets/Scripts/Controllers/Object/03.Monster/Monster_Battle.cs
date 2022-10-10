using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static Define;

public partial class Monster : AI
{
    void AttackRandom()
    {
        Debug.Log("오크의 내려찍기1");
        //_attack.BasicAttack(101);

        PostAttack();
    }

    void OnHitEvent()
    {
        if (_lockTarget != null)
        {
            Charater cl = _lockTarget.GetComponent<Charater>();

            //cl.OnAttacked(gameObject);
            if (Hp > 0)
            {
                float distance = (_lockTarget.transform.position - transform.position).magnitude;
                if (distance <= attackInfo.m_fRange)
                    State = CreatureState.Skill;
                else
                    State = CreatureState.Move;
            }
            else
                State = CreatureState.Idle;
        }
        else
            State = CreatureState.Idle;
    }

    void PostAttack()
    {
        // 다시 공격 거리 안에 있다면 공격 아니면 Move
        Debug.Log("공격 아니면 이동");
    }
}
