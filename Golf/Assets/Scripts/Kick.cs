using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    [SerializeField] private float _Speed_Multiplier = 1.5f;
    [Min(1)]
    [SerializeField] private float _Kick_Force_Limiter;
    [SerializeField] private Transform _Stick_Head;
    
    private Rigidbody _Ball_Rigidbody;
    private float _Ball_Velocity;
    
    private StickSwing _Stick_Swing_Script;
    private float _Distance_To_Ball;

    private float _Kick_Force;
    

    private void Awake()
    {
        _Stick_Swing_Script = GetComponent<StickSwing>();
        _Ball_Rigidbody = _Stick_Swing_Script.Ball.GetComponent<Rigidbody>();

        GameEvents._New_Move += StopBall;
    }
    
    public IEnumerator StartKick(float _stick_Angle, Transform _stick_Anchor)
    {
        float _kick_Distance = 0.17f;
        
        LimitForce(_Stick_Swing_Script.StickAngle);
        
        _Distance_To_Ball = (_Stick_Swing_Script.Ball.transform.position - _Stick_Head.transform.position).magnitude;
        
        while (_Distance_To_Ball > _kick_Distance)
        {
            _Distance_To_Ball = (_Stick_Swing_Script.Ball.transform.position - _Stick_Head.transform.position).magnitude;
            _stick_Anchor.Rotate(Vector3.forward * _stick_Angle * -_Speed_Multiplier * Time.deltaTime);
            yield return null;
        }
        _Stick_Swing_Script.Ball.GetComponent<Rigidbody>().AddForce(-_Stick_Head.transform.forward * _Kick_Force, ForceMode.Impulse);

        StartCoroutine(BallIsMove());
        GameEvents.BallIsMove();
        
    }
    
    public void LimitForce(float _stick_Angle)
    {
        _Kick_Force = Mathf.Abs(_stick_Angle / _Kick_Force_Limiter);
    }
    
    private IEnumerator BallIsMove()
    {
        float _start_Offset = 0.1f;
        yield return new WaitForSeconds(_start_Offset);
        _Ball_Velocity = _Ball_Rigidbody.velocity.magnitude;
        while (_Ball_Velocity > 0)
        {
            _Ball_Velocity = _Ball_Rigidbody.velocity.magnitude;
            yield return null;
        }
        GameEvents.BallIsStopped();
    }

    private void StopBall()
    {
        _Ball_Rigidbody.velocity = Vector3.zero;
        _Ball_Rigidbody.angularVelocity = Vector3.zero;
    }

    private void OnDisable()
    {
        GameEvents._New_Move -= StopBall;
    }

    private void OnDestroy()
    {
        GameEvents._New_Move -= StopBall;
    }
}
