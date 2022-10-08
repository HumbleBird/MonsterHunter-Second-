using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static Define;

public partial class AI : Charater
{
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

    protected Table_AI.Info aiInfo;

    protected override void UpdateController()
    {
        base.UpdateController();

        switch (State)
        {
            case CreatureState.Idle:
                EnviromentView();             //  Check whether or not the player is in the enemy's field of vision
                break;
            case CreatureState.Move:
                EnviromentView();             //  Check whether or not the player is in the enemy's field of vision
                MoveAI();
                break;
        }
    }
}
