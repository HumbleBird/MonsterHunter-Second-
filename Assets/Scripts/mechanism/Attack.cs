using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Table_Attack;

public abstract class Attack : MonoBehaviour
{
    Blow blow; // 근접 (검사, 건투가 등)
    Range range; // 원거리 (거너, 마법사 등)

    Dictionary<int, Info> _dic = null;

    protected virtual void Init()
    {
        _dic = Managers.Table.m_Attack.m_Dictionary;
    }

    // 기본 공격(연사기)
    public virtual void BasicAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }

    public virtual void Skill()
    {

    }

    public virtual void Kick()
    {
        
    }
}
