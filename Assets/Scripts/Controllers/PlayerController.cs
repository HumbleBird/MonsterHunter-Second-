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
		// 키보드 (이동)
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
		// 애니메이션 (애니메이션 자체에 이동이 포함되어 있음)
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		// Shft키를 안누르면 최대 0.5, Shft키를 누르면 최대 1까지 값이 바뀌게 된다
		float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;

		// horizontal 값에 따라 애니메이션 재생 (-1:왼쪽, 0:가운데, 1:오른쪽)
		_animator.SetFloat("Horizontal", horizontal * offset);
		// vertical 값에 따라 애니메이션 재생 (-1:뒤, 0:가운데, 1:앞)
		_animator.SetFloat("Vertical", vertical * offset);

		// 이동속도 : Shift키를 안눌렀을 땐 walkSpeed, Shift키를 눌렀을 땐 runSpeed값이 moveSpeed에 저장
		//float moveSpeed = Mathf.Lerp(walkSpeed, runSpeed, Input.GetAxis("Sprint"));
	}

	protected virtual void UpdateSkill()
    {
		// 기본 스킬
		//BaseAttack();
		

		State = CreatureState.Idle;
	}
}
