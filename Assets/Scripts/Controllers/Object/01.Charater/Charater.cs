using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public partial class Charater : Base
{
    [SerializeField]
    protected Vector3 _destPos;

    CreatureState _state = CreatureState.Idle;
	public CreatureState State
    {
		get { return _state;}
        set
        {
			if (_state == value)
				return;

			_state = value;
			//RefreshAnimation();
        }
    }

	protected override void Init()
	{
        base.Init();

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

    // TODO Trans
}
