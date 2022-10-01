using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class Player : Charater
{
	IAttack _attack = new Blow();

	protected override void Init()
    {
		base.Init();

		Table_Stat.Info stat = null;
		Managers.Table.m_Stat.m_Dictionary.TryGetValue(1001, out stat);
		_stat = stat;


		// TODO
		Table_Attack.Info attackInfo = null;
		Managers.Table.m_Attack.m_Dictionary.TryGetValue(100001, out attackInfo);
		_attackInfo = attackInfo;

		_attack.Init(gameObject);
	}

	protected override void Update()
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

    protected override void OnHitEvent()
    {
		if(_lockTarget != null)
        {
			Charater cl =_lockTarget.GetComponent<Charater>();
			cl.OnAttacked(transform.gameObject);
        }
    }

	public void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
			_attack.BasicAttack();
        }
		
    }


}
