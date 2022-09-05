using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class PlayerController : MonoBehaviour
{
    CreatureState _state = CreatureState.Idle;
	MoveDir _dir;

    private float _moveSpeed = 10.0f;
    private float jumpHeight = 1.0f;

    Rigidbody _rigid;
    CapsuleCollider _capsule;
	Animator _animator = null;

	public virtual CreatureState State
	{
		get { return _state; }
		set
		{
			if (_state == value)
				return;

			_state = value;
			UpdateAnimation();
		}
	}

	protected virtual void UpdateAnimation()
	{
		if (_animator == null)
			return;

		if (State == CreatureState.Idle)
		{
			_animator.Play("IDLE");
		}
		else if (State == CreatureState.Move)
		{
			_animator.Play("Move");
		}
		else if (State == CreatureState.Skill)
		{
			_animator.Play("Skill");
		}
		else if (State == CreatureState.Dead)
		{
			_animator.Play("Dead");
		}
	}

	private void Start()
    {
		Init();

	}

	protected virtual void Init()
	{
		_rigid = GetComponent<Rigidbody>();
		_capsule = GetComponent<CapsuleCollider>();
		_animator = GetComponent<Animator>();

		UpdateAnimation();
	}

	void Update()
    {
        UpdateController();
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
                break;
            case CreatureState.Dead:
                break;
            default:
                break;
        }
    }

	void GetInputKey()
    {
		if (Input.anyKey)
		{
			State = CreatureState.Move;
		}
        else
        {
			State = CreatureState.Idle;
        }
	}


    protected virtual void UpdateIdle()
    {

    }

	protected virtual void UpdateMove()
    {
		float x_Axis = Input.GetAxisRaw("Horizontal");
		float z_Axis = Input.GetAxisRaw("Vertical");

		Vector3 dir = new Vector3(x_Axis, 0, z_Axis);

		transform.position += dir * _moveSpeed * Time.deltaTime;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			transform.Translate(Vector3.up * jumpHeight);
		}
	}
}
