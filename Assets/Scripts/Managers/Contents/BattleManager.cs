using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // À¯´Ö°ü¸®

    public PlayerController _player { get; set; }
    //Dictionary<int, GameObject> _objects = new Dictionary<int, GameObject>();
    List<GameObject> _objects = new List<GameObject>();

    public void Add(GameObject go)
    {
        _objects.Add(go);
    }

    public void Remove(GameObject go)
    {
        _objects.Remove(go);
    }

    public GameObject Find(GameObject go)
    {
        foreach (GameObject obj in _objects)
        {
            if (obj == go)
                return obj;
        }
        return null;
    }

    public void Clear()
    {
        _objects.Clear();
    }
}
