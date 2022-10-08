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
		// �ִϸ��̼� (�ִϸ��̼� ��ü�� �̵��� ���ԵǾ� ����)
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		// ShftŰ�� �ȴ����� �ִ� 0.5, ShftŰ�� ������ �ִ� 1���� ���� �ٲ�� �ȴ�
		float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;

		Vector3 move = new Vector3(horizontal, 0, vertical);
		
		// �ȱ�
		if(offset == 0)
        {
			transform.position += move * statInfo.m_fWalkSpeed * Time.deltaTime;
		}
		else if(offset != 0)
        {
			transform.position += move * statInfo.m_fRunSpeed * Time.deltaTime;
		}

		// �ִϸ��̼�
		Animator.SetFloat("Horizontal", horizontal * offset);
		Animator.SetFloat("Vertical", vertical * offset);

		// �̵��ӵ� : ShiftŰ�� �ȴ����� �� walkSpeed, ShiftŰ�� ������ �� runSpeed���� moveSpeed�� ����
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
		// ������ �ϴ� ���� �� �����̰� �ϱ�
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
