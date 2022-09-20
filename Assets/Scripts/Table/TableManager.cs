using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    public Table_Camera m_Camera = new Table_Camera();
    public Table_Stat m_Stat = new Table_Stat();

    public void Init()
    {
#if UNITY_EDITOR
        m_Camera.Init_CSV("Camera", 2, 0);
        m_Stat.Init_CSV("Stat", 2, 0);
        
#else
        m_Camera.Init_Binary("Camera");
#endif
    }

    public void Save()
    {
        m_Camera.Save_Binary("Camera");
        m_Stat.Save_Binary("Stat");

#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }
}
