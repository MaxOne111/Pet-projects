using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public static Action _Ball_Is_Move;
    public static Action _Ball_Is_Stopped;
    public static Action _New_Move;
    
    public static void BallIsMove()
    {
        _Ball_Is_Move.Invoke();
    }

    public static void BallIsStopped()
    {
        _Ball_Is_Stopped.Invoke();
    }

    public static void NewMove()
    {
        _New_Move.Invoke();
    }
}
