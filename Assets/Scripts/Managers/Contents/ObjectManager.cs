using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager
{
	Dictionary<int, GameObject> _objects = new Dictionary<int, GameObject>();
	//List<GameObject> _objects = new List<GameObject>();

	public void Add(int id, GameObject go)
	{
		_objects.Add(id, go);
	}

	public void Remove(int id)
	{
		_objects.Remove(id);
	}

	public GameObject Find(int id)
    {
		GameObject obj = null;
		_objects.TryGetValue(id, out obj);
		if (obj == null)
			return null;

		return obj;
    }

	//public GameObject Find(Func<GameObject, bool> condition)
	//{
	//	foreach (GameObject obj in _objects)
	//	{
	//		if (condition.Invoke(obj))
	//			return obj;
	//	}

	//	return null;
	//}

	public void Clear()
	{
		_objects.Clear();
	}

	public void Spawn(int id)
	{
		// 해당하는 id의 플레이어가 있다면
		if(Managers.Table.m_Player.Get(id) != null)
        {
			Table_Player.Info pinfo = Managers.Table.m_Player.Get(id);
			GameObject go = Managers.Resource.Instantiate(pinfo.m_sPrefabPath);
			go.GetComponent<Charater>().SetInfo(pinfo.m_nID);
			_objects.Add(pinfo.m_nID, go); // 이게 필요하나?
		}
		// 해당하는 
		else if (Managers.Table.m_Boss.Get(id) != null)
        {
			Table_Boss.Info binfo = Managers.Table.m_Boss.Get(id);
			GameObject go = Managers.Resource.Instantiate(binfo.m_sPrefabPath);
			go.GetComponent<Charater>().SetInfo(binfo.m_nID);
			_objects.Add(binfo.m_nID, go); // 이게 필요하나?
		}
		// TODO Monster
	}
}
