﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Action : Strategy
{
    // 구르기
    // 상호작용 등

    public void Roll()
    {
        m_cGo.waiting = true;
        m_cGo.Animator.SetBool("Stand To Roll", true);
    }
}
