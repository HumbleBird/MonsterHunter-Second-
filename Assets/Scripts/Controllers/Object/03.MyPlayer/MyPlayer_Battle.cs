using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public partial class MyPlayer : Player
{
	void Attack()
    {
		if (Input.GetMouseButtonDown(0))
			_attack.BasicAttack();
	}

	protected void AttackingCheck()
	{
		// 공격을 하는 동안 못 움직이게 하기
		float curAnimationTime = Animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
		if (curAnimationTime >= 1)
		{
			State = CreatureState.Move;
		}
        else
        {
			State = CreatureState.Skill;
        }
	}
}
