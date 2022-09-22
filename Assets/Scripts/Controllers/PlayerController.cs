using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class PlayerController : Charater
{
    protected override void Init()
    {
		base.Init();

		Dictionary<int, Table_Stat.Info> dict = Managers.Table.m_Stat.m_Dictionary;
		Table_Stat.Info stat = dict[1001];
	}


	protected override void Update()
    {
		GetInputKey();
	}

	void GetInputKey()
    {
		Move();
		Attack();
	}

	void Move()
    {
		// 애니메이션 (애니메이션 자체에 이동이 포함되어 있음)
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		// Shft키를 안누르면 최대 0.5, Shft키를 누르면 최대 1까지 값이 바뀌게 된다
		float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;

		_animator.SetFloat("Horizontal", horizontal * offset);
		_animator.SetFloat("Vertical", vertical * offset);

		// 이동속도 : Shift키를 안눌렀을 땐 walkSpeed, Shift키를 눌렀을 땐 runSpeed값이 moveSpeed에 저장
		//float moveSpeed = Mathf.Lerp(walkSpeed, runSpeed, Input.GetAxis("Sprint"));
	}

	void Attack()
    {
		if (Input.GetMouseButtonDown(0))
        {
			_animator.SetTrigger("MLClick");

		}
		else if (Input.GetMouseButtonDown(1))
        {
			_animator.SetTrigger("MRClick");
		}
	}

    protected override void OnHitEvent()
    {
		// 스테미나 감소
		// 적중시 적 체력 감소
		// 
    }

}
