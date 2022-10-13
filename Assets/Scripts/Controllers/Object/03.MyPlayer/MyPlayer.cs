using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public partial class MyPlayer : Player
{
	public Collider attackCollider;
	public TrigerDetector trigerDetecter;

    protected override void UpdateController()
    {
        base.UpdateController();

		switch (State)
		{
			case CreatureState.Idle:
				GetInputKeyMove();
				break;
			case CreatureState.Move:
				GetInputKeyMove();
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

		attack();
	}
}
