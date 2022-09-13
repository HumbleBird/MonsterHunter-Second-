using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class PlayerController : MonoBehaviour
{
    CreatureState _state = CreatureState.Idle;
	MoveDir _dir = MoveDir.Idle;

	private float _moveSpeed = 1.0f;
	private float wait_run_ratio = 0.0f;

	Animator _animator = null;

	public MoveDir Dir
    {
		get { return _dir; }
		set{ if (_dir == value) return; _dir = value; UpdateAnimation(); }
	}

	public virtual CreatureState State
	{
		get { return _state; }
		set{ if (_state == value) return;  _state = value; UpdateAnimation(); }
	}

	protected virtual void UpdateAnimation()
	{
		if (_animator == null)
			return;

		if (State == CreatureState.Idle)
		{
			_animator.Play("sword and shield idle");
		}
		else if (State == CreatureState.Move)
		{
            switch (Dir)
            {
                case MoveDir.Front:
                    {
						_animator.Play("sword and shield walk_f");
					}
					break;
				case MoveDir.Back:
				    _animator.Play("sword and shield walk_b");
                    break;
				case MoveDir.Left:
					_animator.Play("sword and shield strafe_l");
					break;
                case MoveDir.Right:
					_animator.Play("sword and shield strafe_r");
					break;
                default:
                    break;
            }
		}
		// 나중에는 skill을 dick으로 관리
		else if (State == CreatureState.Skill)
		{

		}
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
	}

    protected virtual void UpdateIdle()
    {

    }

	protected virtual void UpdateMove()
    {
		//Vector3 pos = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		if (Input.GetKey(KeyCode.W))
		{
			wait_run_ratio = Mathf.Lerp(wait_run_ratio, 1, 10.0f * Time.deltaTime);
			_animator.SetFloat("wait_run_ratio", wait_run_ratio);
			Dir = MoveDir.Front;
		}
		else if (Input.GetKey(KeyCode.S))
		{
			Dir = MoveDir.Back;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			Dir = MoveDir.Right;
		}
		else if (Input.GetKey(KeyCode.A))
		{
			Dir = MoveDir.Left;
		}
        else
        {
			wait_run_ratio = Mathf.Lerp(wait_run_ratio, 0, 10.0f * Time.deltaTime);
			_animator.SetFloat("wait_run_ratio", wait_run_ratio);
			Dir = MoveDir.Idle;
        }

		//transform.position += pos * _moveSpeed * Time.deltaTime;
    }

    protected virtual void UpdateSkill()
    {
    }
}
