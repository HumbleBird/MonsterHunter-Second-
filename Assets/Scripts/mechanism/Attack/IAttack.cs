using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IAttack
{
    public void Init(GameObject o);
    public void BasicAttack();
    public void Skill();
    public void Kick();
}
