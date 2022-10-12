using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static Define;

public partial class AI : Charater
{
    protected Table_AI.Info aiInfo; // 길 찾기를 위한 대기 시간 및 시야 각도 등

    public override CreatureState State
    {
        get { return _state; }
        set
        {
            if (_state == value)
                return;

            _state = value;
            RefreshAnimation();
        }
    }

    protected override void UpdateController()
    {
        base.UpdateController();

        switch (State)
        {
            case CreatureState.Idle:
                EnviromentView();
                RandomChangeState();
                break;
            case CreatureState.Move:
                EnviromentView();
                StartCoroutine("MoveAI");
                break;
        }
    }

    float time = 3f;
    void RandomChangeState()
    {
        if (m_playerInRange == true)
        {
            State = CreatureState.Move;
            return;
        }

        if (time <= 0)
        {
            int Rand = UnityEngine.Random.Range(0, 2);
            if (Rand == 0)
            {
                State = CreatureState.Idle;
            }
            else
            {
                State = CreatureState.Move;
            }
            time = 3f;
            return;
        }
        else
        {
            time -= Time.deltaTime;
        }

    }
}
