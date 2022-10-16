using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : Charater
{
    protected override void Update()
    {
        base.Update();

        Rotate();
    }

    void Rotate()
    {
        transform.Rotate(0f, rotation, 0f);
    }
}
