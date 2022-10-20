using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Attack
{
    protected GameObject m_Go; // 공격자
    protected Charater   m_cGo;

    protected GameObject m_GOTarget; // 피격자

    protected GameObject m_GOProjectile = null; // 투사체

    public virtual void Init(GameObject go)
    {
        m_Go = go.gameObject;
        m_cGo = m_Go.GetComponent<Charater>();
    }

    public abstract IEnumerator BasicAttack(int id = 1);
    public abstract void Skill();
    public virtual void Kick() { }

    public abstract void NextAttackCheck();
}
