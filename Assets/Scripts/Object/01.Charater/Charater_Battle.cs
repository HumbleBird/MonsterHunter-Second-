using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public partial class Charater : Base
{
    // 접근점
    protected IAttack _attack;

    public void ChangeIAttack(string typeClass)
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
    }
}
