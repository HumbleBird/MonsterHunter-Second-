using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public partial class MyPlayer : Player
{
	Coroutine co;

	void GetInputkeyAttack()
	{
		if (Input.GetMouseButtonDown(0) && _isNextCanAttack)
		{
			_isNextCanAttack = false;
			State = CreatureState.Skill;
			co = StartCoroutine(_attack.BasicAttack());
		}
	}

	public override void HitEvent()
	{
		_detectorItem.Set();
	}
}
