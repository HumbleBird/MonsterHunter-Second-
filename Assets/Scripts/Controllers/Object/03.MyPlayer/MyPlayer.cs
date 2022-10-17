using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public partial class MyPlayer : Player
{
	public GameObject followTransform;
	public Vector2 _look;

	public float rotationPower = 3f;
	public float rotationLerp = 0.5f;

	protected override void UpdateController()
    {
        base.UpdateController();

		switch (State)
		{
			case CreatureState.Idle:
				GetDirInput();
				GetInputkeyAttack();
				break;
			case CreatureState.Move:
				GetDirInput();
				GetInputkeyAttack();
				break;
			case CreatureState.Skill:
				break;
			case CreatureState.Dead:
				break;
		}
	}

	bool _moveKeyPressed = false;
	protected override void UpdateIdle()
    {
		// �̵� ���·� ���� Ȯ��
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
		else
			_moveKeyPressed = false;
	}

    protected override void UpdateMove()
    {
		// �ִϸ��̼� (�ִϸ��̼� ��ü�� �̵��� ���ԵǾ� ����)
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		float speed = WalkSpeed;

		Vector3 move = new Vector3(horizontal, 0, vertical);
		
		float inputMagnitude = Mathf.Clamp01(move.magnitude);
		inputMagnitude /= 2;

		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			inputMagnitude *= 2;
			speed = RunSpeed;
		}

		transform.position += move * speed * Time.deltaTime;
		Animator.SetFloat("Sprint", inputMagnitude, 0.05f, Time.deltaTime);

		#region Player Rotation
		followTransform.transform.rotation *= Quaternion.AngleAxis(_look.y * rotationPower, Vector3.right);

		var angles = followTransform.transform.localEulerAngles;
		angles.z = 0;

		var angle = followTransform.transform.localEulerAngles.x;

		//Clamp the Up/Down rotation
		if (angle > 180 && angle < 340)
		{
			angles.x = 340;
		}
		else if (angle < 180 && angle > 40)
		{
			angles.x = 40;
		}


		followTransform.transform.localEulerAngles = angles;

		#endregion
		// �̵��ӵ� : ShiftŰ�� �ȴ����� �� walkSpeed, ShiftŰ�� ������ �� runSpeed���� moveSpeed�� ����
		//float moveSpeed = Mathf.Lerp(walkSpeed, runSpeed, Input.GetAxis("Sprint"));
	}
}
