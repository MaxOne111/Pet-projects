using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameEvents
{
    public static Action<Vector3> _Take_Bonus;
    public static Action _Defeat;

    public static void TakeBonus(Vector3 _bonus_Position)
    {
        _Take_Bonus.Invoke(_bonus_Position);
    }

    public static void Defeat()
    {
        _Defeat?.Invoke();
    }

    public static void Pause()
    {
        Time.timeScale = 0;
    }

    public static void Play()
    {
        Time.timeScale = 1;
    }

    public static void Repeat()
    {
        SceneManager.LoadScene(0);
    }

    public static void Exit()
    {
        Application.Quit();
    }
}
