using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public partial class MyPlayer : Player
{
	public GameObject followTransform;
	Camera m_tCamera;

	protected override void Start()
	{
		base.Start();

		m_tCamera = Camera.main;
	}

    protected override void Update()
    {
        base.Update();

		if (Input.GetKey(KeyCode.I))
		{
			Managers.Camera.ZoomEndStage(0f, -1.5f, 1.5f, 3f - 1.5f, 0.5f, Vector3.zero);
		}
	}

    protected override void UpdateController()
    {
        base.UpdateController();

		switch (State)
		{
			case CreatureState.Idle:
				GetInputKey();
				break;
			case CreatureState.Move:
				GetInputKey();
				break;
			case CreatureState.Skill:
				break;
			case CreatureState.Dead:
				break;
		}
	}

	void GetInputKey()
    {
		GetDirInput();
		GetInputkeyAttack();
		GetMoveActionInput();
	}

    bool _moveKeyPressed = false;
	protected override void UpdateIdle()
    {
		// 이동 상태로 갈지 확인
		if (_moveKeyPressed)
		{
			State = CreatureState.Move;
			return;
		}
	}

	void GetDirInput()
	{
		_moveKeyPressed = true;
		if (Input.GetKey(KeyCode.W) ||
		   Input.GetKey(KeyCode.A) ||
		   Input.GetKey(KeyCode.S) ||
		   Input.GetKey(KeyCode.D))
			State = CreatureState.Move;
		_moveKeyPressed = false;
	}

	protected void GetMoveActionInput()
	{
		if (Input.GetKey(KeyCode.Space))
			m_stPlayerMove.Roll();

        if (Input.GetKeyDown(KeyCode.LeftControl))
            m_stPlayerMove.Crounch(PlayerActionMoveState.Start);
        else if (Input.GetKey(KeyCode.LeftControl))
            m_stPlayerMove.Crounch(PlayerActionMoveState.Idle);
        else if (Input.GetKeyUp(KeyCode.LeftControl))
            m_stPlayerMove.Crounch(PlayerActionMoveState.End);
		else
            m_stPlayerMove.Crounch(PlayerActionMoveState.None);
	}

	protected override void UpdateMove()
    {
		if (waiting)
			return;

		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		float speed = WalkSpeed;

		Vector3 move = new Vector3(horizontal, 0, vertical);
		move = Quaternion.AngleAxis(m_tCamera.transform.rotation.eulerAngles.y, Vector3.up) * move;

		float inputMagnitude = Mathf.Clamp01(move.magnitude);
		inputMagnitude /= 2;

		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			inputMagnitude *= 2;
			speed = RunSpeed;
		}

		transform.position += move * speed * Time.deltaTime;

		if (move != Vector3.zero)
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), 10 * Time.deltaTime);

		Animator.SetFloat("Sprint", inputMagnitude, 0.05f, Time.deltaTime);
	}
}
