using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static Define;

public class Monster : AI
{
    [SerializeField]
    float _scanRange = 10;

    [SerializeField]
    float _attackRange = 2;

    Table_Boss.Info bossInfo;

    public override void SetInfo(int id)
    {
        bossInfo = Managers.Table.m_Boss.Get(id);
        statInfo = Managers.Table.m_Stat.Get(bossInfo.m_iStat);
    }

    protected override void UpdateIdle()
    {
        float distance = (target.transform.position - transform.position).magnitude;
        if (distance <= _scanRange)
        {
            _lockTarget = target;
            State = CreatureState.Move;
            return;
        }
    }

    protected override void UpdateMove()
    {
        // 플레이어가 내 사정거리보다 가까우면 공격
        if (_lockTarget == null)
        {
            _destPos = _lockTarget.transform.position;
            float distance = (_destPos - transform.position).magnitude;
            if (distance <= _attackRange)
            {
                NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
                nma.SetDestination(transform.position);
                State = CreatureState.Skill;
                return;
            }
        }

        // 이동
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.1f)
        {
            State = CreatureState.Idle;
        }
        else
        {
            NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
            nma.SetDestination(_destPos);
            nma.speed = WalkSpeed;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
        }
    }

    // TODO
    protected override void UpdateSkill()
    {
        if (_lockTarget == null)
            return;

        Vector3 dir = _lockTarget.transform.position - transform.position;
        Quaternion quat = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, quat, 20 * Time.deltaTime);
    }

    void OnHitEvent()
    {
        if (_lockTarget != null)
        {
            Charater cl = _lockTarget.GetComponent<Charater>();
            // 쿨타임

            //cl.OnAttacked(gameObject);

            if (Hp > 0)
            {
                float distance = (_lockTarget.transform.position - transform.position).magnitude;
                if (distance <= _attackRange)
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
