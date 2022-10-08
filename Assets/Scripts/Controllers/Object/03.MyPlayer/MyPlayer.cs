using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class MyPlayer : Player
{
    protected override void Init()
    {
        base.Init();

		target = Managers.Object.Find(101);
	}

    protected override void UpdateController()
    {
        base.UpdateController();

		switch (State)
		{
			case CreatureState.Idle:
				GetInputKeyMove();
				Attack();
				break;
			case CreatureState.Move:
				GetInputKeyMove();
				Attack();
				break;
			case CreatureState.Skill:
				break;
			case CreatureState.Dead:
				break;
		}
	}

    void GetInputKeyMove()
    {
		// 애니메이션 (애니메이션 자체에 이동이 포함되어 있음)
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		// Shft키를 안누르면 최대 0.5, Shft키를 누르면 최대 1까지 값이 바뀌게 된다
		float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;

		Vector3 move = new Vector3(horizontal, 0, vertical);
		
		// 걷기
		if(offset == 0)
        {
			transform.position += move * statInfo.m_fWalkSpeed * Time.deltaTime;
		}
		else if(offset != 0)
        {
			transform.position += move * statInfo.m_fRunSpeed * Time.deltaTime;
		}

		// 애니메이션
		Animator.SetFloat("Horizontal", horizontal * offset);
		Animator.SetFloat("Vertical", vertical * offset);

		// 이동속도 : Shift키를 안눌렀을 땐 walkSpeed, Shift키를 눌렀을 땐 runSpeed값이 moveSpeed에 저장
		//float moveSpeed = Mathf.Lerp(walkSpeed, runSpeed, Input.GetAxis("Sprint"));
	}

	// TODO
	void Attack()
    {
		if (Input.GetMouseButtonDown(0))
        {
			_attack.BasicAttack();
			
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
