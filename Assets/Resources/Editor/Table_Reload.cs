using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Table_Reload : MonoBehaviour
{
    [MenuItem("CS_Utill/Table/CSV &F1", false, 1)]
    static public void Parser_Table_CSV()
    {
        Managers.Table.Init();
        Managers.Table.Save();
    }

}
