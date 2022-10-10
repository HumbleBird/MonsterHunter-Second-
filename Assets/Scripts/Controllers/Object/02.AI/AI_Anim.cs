using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public partial class AI : Charater
{
    public void RefreshAnimation()
    {
        switch (State)
        {
            case CreatureState.Idle:
                Animator.Play("Idle");
                break;
            case CreatureState.Move:
                Animator.Play("Walk");
                break;
            case CreatureState.Skill:
                //Animator.Play("Attack");
                // 현재 공격하는 공격 ID를 참고하여 애니메이션 재생인데..
                break;
            case CreatureState.Dead:
                Animator.Play("Dead");
                break;
        }
    }
}
