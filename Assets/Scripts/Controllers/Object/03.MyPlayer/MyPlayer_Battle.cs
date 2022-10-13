using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public partial class MyPlayer : Player
{
    public bool _isClick = true;

    void attack()
    {
        if (Input.GetMouseButtonDown(0) && _isClick)
        {
            _isClick = false;
            _attack.BasicAttack();
            StartCoroutine(_attack.NextAttackCheck());
            Debug.Log("a");
        }
    }

}
