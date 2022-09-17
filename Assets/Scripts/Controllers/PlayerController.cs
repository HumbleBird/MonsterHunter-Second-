using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class PlayerController : Charater
{
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
			_animator.SetTrigger("MLClick");
		else if (Input.GetMouseButtonDown(1))
			_animator.SetTrigger("MRClick");
	}

	bool _isGround = true;
	void Jump()
    {
		if (Input.GetKeyDown("Space") && _isGround == true)
        {
			_isGround = false;
			_animator.SetTrigger("OnJump");
		}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
			_isGround = true;
        }
    }


}
