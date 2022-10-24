using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : Charater
{
    public void Attack(GameObject obj)
    {
        Managers.Battle.HitEvent(gameObject, (int)Atk, obj);
    }

    public override void HitEvent()
    {
        TrigerDetector _detectorItem = _attackItem.GetComponentInChildren<TrigerDetector>();

        _detectorItem.Set();
    }


}
