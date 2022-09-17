using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    Blow blow;
    Range range;

    protected virtual void Init()
    {

    }

    public virtual void BasicAttack()
    {
        ;
    }
    public virtual void BasicEnforceAttack()
    {
        ;
    }
    public virtual void Kick()
    {
        ;
    }
}
