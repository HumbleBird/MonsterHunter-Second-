using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IAttack
{
    public void SetInfo(GameObject go);
    public void BasicAttack();
    public void Kick();
}
