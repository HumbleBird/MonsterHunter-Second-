using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TableManager 
{
    public Table_Camera m_Camera = new Table_Camera();
    public Table_Stat m_Stat = new Table_Stat();
    public Table_Attack m_Attack = new Table_Attack();

    public void Init()
    {
        m_Camera.Init_CSV("Camera", 2, 0);
#if UNITY_EDITOR
        m_Stat.Init_CSV("Stat", 2, 0);
        m_Attack.Init_CSV("Attack", 2, 0);
        
#else
        m_Camera.Init_Binary("Camera");
#endif
    }

    public void Save()
    {
        m_Camera.Save_Binary("Camera");
        m_Stat.Save_Binary("Stat");
        m_Attack.Save_Binary("Attack");

#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }
}
