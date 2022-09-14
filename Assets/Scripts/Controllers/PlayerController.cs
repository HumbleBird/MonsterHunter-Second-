using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class PlayerController : MonoBehaviour
{
    CreatureState _state = CreatureState.Idle;

	Animator _animator = null;
	int _attackCount = 0;

	public virtual CreatureState State
	{
		get { return _state; }
		set{ if (_state == value) return;  _state = value; UpdateAnimation(); }
	}

	protected virtual void UpdateAnimation()
	{
		if (_animator == null)
			return;

		else if (State == CreatureState.Dead)
		{
			_animator.Play("sword and shield death");
		}
	}

	private void Start()
    {
		Init();

	}

	protected virtual void Init()
	{
		_animator = GetComponent<Animator>();
	}

	void Update()
    {
        UpdateController();
		UpdateAnimation();
    }

    protected virtual void UpdateController()
    {
        switch (State)
        {
            case CreatureState.Idle:
				GetInputKey();
				UpdateIdle();
				break;
            case CreatureState.Move:
				GetInputKey();
				UpdateMove();
				break;
            case CreatureState.Skill:
				UpdateSkill();
				break;
            case CreatureState.Dead:
                break;
        }
    }

	void GetInputKey()
    {
		// Ű���� (�̵�)
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) ||
			Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
			State = CreatureState.Move;

		else if (Input.GetMouseButtonDown(0))
			State = CreatureState.Skill;
	}

    protected virtual void UpdateIdle()
    {

    }

	protected virtual void UpdateMove()
    {
		// �ִϸ��̼� (�ִϸ��̼� ��ü�� �̵��� ���ԵǾ� ����)
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		// ShftŰ�� �ȴ����� �ִ� 0.5, ShftŰ�� ������ �ִ� 1���� ���� �ٲ�� �ȴ�
		float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;

		// horizontal ���� ���� �ִϸ��̼� ��� (-1:����, 0:���, 1:������)
		_animator.SetFloat("Horizontal", horizontal * offset);
		// vertical ���� ���� �ִϸ��̼� ��� (-1:��, 0:���, 1:��)
		_animator.SetFloat("Vertical", vertical * offset);

		// �̵��ӵ� : ShiftŰ�� �ȴ����� �� walkSpeed, ShiftŰ�� ������ �� runSpeed���� moveSpeed�� ����
		//float moveSpeed = Mathf.Lerp(walkSpeed, runSpeed, Input.GetAxis("Sprint"));
	}

	protected virtual void UpdateSkill()
    {
		// �⺻ ��ų
		//BaseAttack();
		

		State = CreatureState.Idle;
	}
}
