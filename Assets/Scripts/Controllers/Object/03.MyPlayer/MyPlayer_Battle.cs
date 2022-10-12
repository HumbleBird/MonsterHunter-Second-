using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public partial class MyPlayer : Player
{
	public float cooldownTime = 0.8f;
	private float nextFireTime = 0f;
	public static int noOfClicks = 0;
	float lastClickedTime = 0;
	float maxComboDelay = 1;

	void Attack2()
    {
		if (Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && Animator.GetCurrentAnimatorStateInfo(0).IsName("BasicAttack1"))
		{
			Animator.SetBool("BasicAttack1", false);
		}
		if (Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && Animator.GetCurrentAnimatorStateInfo(0).IsName("BasicAttack2"))
		{
			Animator.SetBool("BasicAttack2", false);
		}
		if (Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && Animator.GetCurrentAnimatorStateInfo(0).IsName("BasicAttack3"))
		{
			Animator.SetBool("BasicAttack3", false);
			noOfClicks = 0;
		}

		if (Time.time - lastClickedTime > maxComboDelay)
		{
			noOfClicks = 0;
		}

		//cooldown time
		if (Time.time > nextFireTime)
		{
			// Check for mouse input
			if (Input.GetMouseButtonDown(0))
			{
				OnClick();
			}
		}
	}

	void OnClick()
	{
		//so it looks at how many clicks have been made and if one animation has finished playing starts another one.
		lastClickedTime = Time.time;
		_attack.BasicAttack();


		noOfClicks++;
		if (noOfClicks == 1)
		{
			Animator.SetBool("BasicAttack1", true);
		}


		if (noOfClicks >= 2 && Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && Animator.GetCurrentAnimatorStateInfo(0).IsName("BasicAttack1"))
		{
			Animator.SetBool("BasicAttack1", false);
			Animator.SetBool("BasicAttack2", true);
		}
		if (noOfClicks >= 3 && Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && Animator.GetCurrentAnimatorStateInfo(0).IsName("BasicAttack2"))
		{
			Animator.SetBool("BasicAttack2", false);
			Animator.SetBool("BasicAttack3", true);
		}
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
