using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public abstract partial class Charater : Base
{
    public Table_Stat.Info statInfo { get; set; } = new Table_Stat.Info();
    public Dictionary<int, Table_Attack.Info> attackInfo { get; set; } = new Dictionary<int, Table_Attack.Info>();
    public abstract void SetInfo(int id);

    // 만약
    #region Stat
    public int Hp { get { return statInfo.m_iHp; } set { statInfo.m_iHp = value; } }
    public int MaxHp { get; set; }
    public int Stamina { get { return statInfo.m_iStemina; } set { statInfo.m_iStemina = value; } }
    public int MaxStamina { get; set; }
    public float Atk { get { return statInfo.m_fAtk; } set { statInfo.m_fAtk = value; } }
    public float Def { get { return statInfo.m_fDef; } set { statInfo.m_fDef = value; } }
    public float WalkSpeed { get { return statInfo.m_fWalkSpeed; } set { statInfo.m_fWalkSpeed = value; } }
    #endregion

    // 나중에 Stat은? Equipment는 붙여야 됨?
    // TODO Player AttackInfo Dict에 다 넣어 줘야 함. 수동으로
    public Table_Attack.Info GetAttackInfo(int id)
    {
        if (attackInfo.ContainsKey(id))
            return attackInfo[id];

        return null;
    }
}

