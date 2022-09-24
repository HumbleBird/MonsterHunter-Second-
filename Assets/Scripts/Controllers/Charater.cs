using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class Charater : MonoBehaviour
{
    #region Stat
    public Table_Stat.Info _stat = new Table_Stat.Info();
    public int Hp { get { return _stat.m_iHp; } set { _stat.m_iHp = value; }}
    public int MaxHp { get; set; }
    public int Stamina { get { return _stat.m_iStemina; } set { _stat.m_iStemina = value; } }
    public int MaxStamina { get; set; }
    public float Atk { get { return _stat.m_fAtk; } set { _stat.m_fAtk = value; } }
    public float Def { get { return _stat.m_fDef; } set { _stat.m_fDef = value; } }
    public float WalkSpeed { get { return _stat.m_fWalkSpeed; } set { _stat.m_fWalkSpeed = value; } }
    #endregion

    #region Attack
    public Table_Attack.Info _attackInfo = new Table_Attack.Info();
    public float CoolTime { get { return _attackInfo.m_fCoolTime; } set { _attackInfo.m_fCoolTime = value; } }

    public float _coolTime;
    #endregion


    [SerializeField]
    protected Vector3 _destPos;
    Vector3 m_vCurPos;
    Quaternion m_qCurRot;
    PhotonView PV;

    [SerializeField]
    protected GameObject _lockTarget;
    [SerializeField]
    protected GameObject target; // 타겟

    public Animator _animator { get; set; }
	protected Rigidbody _rigid;

    Battle _battle = new Battle();

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
                //_animator.Play("Attack");
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

    public virtual void OnAttacked(GameObject Atker)
    {
        Charater attacker = Atker.GetComponent<Charater>();

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

    void PhotonDeadReckoning() // 데드레커닝
    {
        transform.position = Vector3.Lerp(transform.position, m_vCurPos, Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, m_qCurRot, Time.deltaTime);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // 로컬 플레이어의 위치 정보 전달
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            m_vCurPos = (Vector3)stream.ReceiveNext();
            m_qCurRot = (Quaternion)stream.ReceiveNext();
        }
    }
}
