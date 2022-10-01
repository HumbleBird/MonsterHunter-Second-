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
		// �ִϸ��̼� (�ִϸ��̼� ��ü�� �̵��� ���ԵǾ� ����)
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		// ShftŰ�� �ȴ����� �ִ� 0.5, ShftŰ�� ������ �ִ� 1���� ���� �ٲ�� �ȴ�
		float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;

		_animator.SetFloat("Horizontal", horizontal * offset);
		_animator.SetFloat("Vertical", vertical * offset);

		// �̵��ӵ� : ShiftŰ�� �ȴ����� �� walkSpeed, ShiftŰ�� ������ �� runSpeed���� moveSpeed�� ����
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
