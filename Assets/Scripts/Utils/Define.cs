using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum MoveDir
    {
        Up,
        Down,
        Left,
        Right
    }

    public enum CreatureState
    {
        Idle,
        Move,
        Skill,
        Dead
    }

    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }

    public enum UIEvent
    {
        Click,
        Drag,
    }
}
