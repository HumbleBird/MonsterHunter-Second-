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

		attack();
	}
}
