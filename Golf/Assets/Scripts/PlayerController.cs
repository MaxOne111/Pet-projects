using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private StickSwing _Stick_Swing;
    [SerializeField] private GameObject _Ball;
    [SerializeField] private Transform Ball_Start_Position;

    private void Awake()
    {
        GameEvents._Ball_Is_Move += ControllerDisable;
        GameEvents._Ball_Is_Stopped += ControllerEnable;
        GameEvents._New_Move += NewMove;
    }

    private void ControllerEnable()
    {
        _Stick_Swing.enabled = true;
    }

    private void ControllerDisable()
    {
        _Stick_Swing.enabled = false;
    }

    private void NewMove()
    {
        _Ball.transform.position = Ball_Start_Position.position;
    }

    private void OnDisable()
    {
        GameEvents._Ball_Is_Move -= ControllerDisable;
        GameEvents._Ball_Is_Stopped -= ControllerEnable;
        GameEvents._New_Move -= NewMove;
    }

    private void OnDestroy()
    {
        GameEvents._Ball_Is_Move -= ControllerDisable;
        GameEvents._Ball_Is_Stopped -= ControllerEnable;
        GameEvents._New_Move -= NewMove;
    }
}
