using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class Player : Charater
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
		if(_lockTarget != null)
        {
			Charater cl =_lockTarget.GetComponent<Charater>();
			cl.OnAttacked(transform.gameObject);
        }
    }

}
