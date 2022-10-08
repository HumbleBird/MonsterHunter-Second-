using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Attack
{
    protected GameObject m_Go = null; // 플레이어
    protected Player m_Player = null;
    protected GameObject m_GOTarget = null; // 타겟
    protected Monster m_TargetMonster = null;

    protected GameObject m_GOProjectile = null; // 투사체

    public virtual void Init()
    {
        m_Go = Managers.Object.Find(1);
        m_Player = m_Go.GetComponent<Player>();

        //m_GOTarget = m_Player.target;
        //m_TargetMonster = m_GOTarget.GetComponent<Monster>();

        ClearAttackInfo();
    }

    public abstract void BasicAttack(int id = 1);
    public abstract void Skill();
    public abstract void Kick();

    protected bool _bNextAttackClick = false;
    protected void NextAttackCheck()
    {
        // 애니메이션 체크
        float curAnimationTime = m_Player.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (curAnimationTime >= 0.8)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _bNextAttackClick = true;
                return;
            }
        }
    }

    protected void ClearAttackInfo()
    {


    }

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
}
