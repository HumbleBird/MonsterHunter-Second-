using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public partial class Charater : Base
{
    // 접근점
    protected Attack _attack;

    [SerializeField]
    protected GameObject _lockTarget;
    public GameObject target { get; set; } // 타겟

    public void ChangeClass(string typeClass)
    {
        switch (typeClass)
        {
            case "Blow":
                _attack = new Blow();
                break;
            case "Range":
                _attack = new Range();
                break;
            default:
                break;
        }

        _attack.Init();
    }
}
