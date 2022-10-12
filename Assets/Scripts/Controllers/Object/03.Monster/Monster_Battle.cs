using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static Define;

public partial class Monster : AI
{
    void AttackRandom()
    {


        _attack.BasicAttack(101);
    }
}
