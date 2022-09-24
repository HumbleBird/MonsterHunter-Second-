using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class Charater : MonoBehaviour
{
    #region Stat
    protected Table_Stat.Info _stat = new Table_Stat.Info();
    public int Hp { get { return _stat.m_iHp; } set { _stat.m_iHp = value; }}
    public int MaxHp { get; set; }
    public int Stamina { get { return _stat.m_iStemina; } set { _stat.m_iStemina = value; } }
    public int MaxStamina { get; set; }
    public float Atk { get { return _stat.m_fAtk; } set { _stat.m_fAtk = value; } }
    public float Def { get { return _stat.m_fDef; } set { _stat.m_fDef = value; } }
    public float WalkSpeed { get { return _stat.m_fWalkSpeed; } set { _stat.m_fWalkSpeed = value; } }
    #endregion

    [SerializeField]
    protected Vector3 _destPos;

    [SerializeField]
    protected GameObject _lockTarget;
    [SerializeField]
    protected GameObject target; // 타겟

    protected Animator _animator;
	protected Rigidbody _rigid;

    CreatureState _state = CreatureState.None;
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

	private void Awake()
	{
		Init();
	}

	protected virtual void Init()
	{
		_animator = GetComponent<Animator>();
		_rigid = GetComponent<Rigidbody>();

        MaxHp = Hp;
        MaxStamina = Stamina;

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

    public virtual void OnAttacked(GameObject Attacker)
    {
        Charater attacker = Attacker.GetComponent<Charater>();

        int damage = (int)Mathf.Max(0, attacker.Atk - Def);
        Hp -= damage;

        // 애니메이션
        _animator.Play("Hit");

        if (Hp <= 0)
        {
            Hp = 0;
            State = CreatureState.Dead;
        }
    }

    protected virtual void OnHitEvent() { }
}
