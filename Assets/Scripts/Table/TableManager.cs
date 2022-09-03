using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    public Table_Camera m_Camera = new Table_Camera();

    public void Init()
    {
#if UNITY_EDITOR
        m_Camera.Init_CSV("Camera", 2, 0);
#else
        m_Camera.Init_Binary("Camera");
#endif
    }

    public void Save()
    {
        m_Camera.Save_Binary("Camera");

#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }
}
