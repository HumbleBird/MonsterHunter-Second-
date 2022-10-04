using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAI
{
    public void Patrol();
    public void Chase();
    public void Attack();
}
