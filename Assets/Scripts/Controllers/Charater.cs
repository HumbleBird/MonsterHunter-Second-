using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class Charater : MonoBehaviour
{
    protected Stat _stat;
    public int Hp;
    public int Defense;

    [SerializeField]
    protected Vector3 _destPos;

    [SerializeField]
    protected GameObject _lockTarget;
    [SerializeField]
    protected GameObject target; // 타겟

    protected Animator _animator;
	protected Rigidbody _rigid;

    protected float _speed = 1f; // Nomal Move Speed

    CreatureState _state = CreatureState.Idle;
	public CreatureState State
    {
		get { return _state;}
        set
        {
			if (_state == value)
				return;

			_state = value;
			RefreshAnimation();
        }
    }

	public void RefreshAnimation()
    {
        switch (State)
        {
            case CreatureState.Idle:
                _animator.Play("Idle");
                break;
            case CreatureState.Move:
                _animator.Play("Walk");
                break;
            case CreatureState.Skill:
                _animator.Play("Attack");
                break;
            case CreatureState.Dead:
                _animator.Play("Dead");
                break;
        }
    }

	private void Start()
	{
		Init();
	}

	protected virtual void Init()
	{
		_animator = GetComponent<Animator>();
		_rigid = GetComponent<Rigidbody>();
	}

	protected virtual void Update()
	{
		UpdateController();
	}

	protected virtual void UpdateController()
    {
        switch (State)
        {
            case CreatureState.Idle:
                UpdateIdle();
                break;
            case CreatureState.Move:
                UpdateMove();
                break;
            case CreatureState.Skill:
                UpdateSkill();
                break;
            case CreatureState.Dead:
                UpdateDead();
                break;
        }
    }

    protected virtual void UpdateIdle() { }
    protected virtual void UpdateMove() { }
    protected virtual void UpdateSkill() { }
    protected virtual void UpdateDead() { }

    protected virtual void OnAttacked(GameObject attacker)
    {
        int damage = 0;// Mathf.Max(0, attacker.Attack - Defense);
        Hp -= damage;
        if (Hp <= 0)
        {
            Hp = 0;
            //OnDead(attacker);
        }
    }
}
