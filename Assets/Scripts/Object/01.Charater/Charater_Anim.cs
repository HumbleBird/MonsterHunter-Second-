using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public partial class Charater : Base
{
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
}
