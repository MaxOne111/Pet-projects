using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickSwing : MonoBehaviour
{
    [SerializeField] private SwingLimit _Swing_Limit;
    [SerializeField] private CameraRotate _Camera_Rotate;
    [field: SerializeField] public Transform Ball { get; private set; }
    [SerializeField] private Transform _Camera_Anchor;
    [SerializeField] private Transform _Stick_Anchor;
    [SerializeField] private GameObject _Stick;
    
    public float StickAngle { get; private set; }
    
    private LineRenderer _Line_Renderer;
    private Kick _Kick_Script;

    private void Awake()
    {
        _Line_Renderer = GetComponent<LineRenderer>();
        _Kick_Script = GetComponent<Kick>();
        
        GameEvents._Ball_Is_Move += HideStick;
        GameEvents._Ball_Is_Stopped += ShowStick;
    }

    private void Start()
    {
        GameEvents._Ball_Is_Stopped += NewPosition;
    }

    private void Update()
    {
        SwingForce();
    }

    private void SwingForce()
    {
        Vector3 _mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
        
        Vector3 _start_Pos = new Vector3(Camera.main.ScreenToWorldPoint(_mouse).x, Camera.main.ScreenToWorldPoint(_mouse).y, Camera.main.ScreenToWorldPoint(_mouse).z);
        Vector3 _end_Pos = Camera.main.ScreenToWorldPoint(_mouse);

        if (Input.GetMouseButtonDown(0))
        {
            _Line_Renderer.enabled = true;
            _Camera_Rotate.DisableCameraRotate();
            
            _Line_Renderer.SetPosition(0, _start_Pos);
        }
        if (Input.GetMouseButton(0))
        {
            float _line_Lenght = Mathf.Abs((_end_Pos - _Line_Renderer.GetPosition(0)).magnitude);
            if (!_Swing_Limit.IsTouch)
            {
                _Line_Renderer.SetPosition(1, _end_Pos);
                Swing();
            }
            else
            {
                _Swing_Limit.LimitLength = Mathf.Abs((_Line_Renderer.GetPosition(1) - _Line_Renderer.GetPosition(0)).magnitude);
                if (_line_Lenght < _Swing_Limit.LimitLength)
                {
                    _Line_Renderer.SetPosition(1, _end_Pos);
                    Swing();
                }
            }
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            _Line_Renderer.enabled = false;
            enabled = false;
            StartCoroutine(_Kick_Script.StartKick(StickAngle, _Stick_Anchor));
            _Swing_Limit.IsTouch = false;
        }
    }
    
    private void Swing()
    {
        float _line_Lenght = Mathf.Abs((_Line_Renderer.GetPosition(1) - _Line_Renderer.GetPosition(0)).magnitude);

        StickAngle = -(_line_Lenght * 50);
        StickAngle = Mathf.Clamp(StickAngle, -90, 0);
        
        _Stick_Anchor.eulerAngles = new Vector3(_Stick_Anchor.eulerAngles.x, _Stick_Anchor.eulerAngles.y, StickAngle);
    }

    private void NewPosition()
    {
        Vector3 _new_Position = new Vector3(Ball.transform.position.x, _Camera_Anchor.transform.position.y,
            Ball.transform.position.z);
        _Stick_Anchor.localEulerAngles = Vector3.zero;
        _Camera_Anchor.transform.position = Vector3.Lerp(_Camera_Anchor.transform.position, _new_Position, 1);
    }

    private void HideStick()
    {
        _Stick.SetActive(false);
    }

    private void ShowStick()
    {
        _Stick.SetActive(true);
    }

    private void OnDestroy()
    {
        GameEvents._Ball_Is_Stopped -= NewPosition;
        GameEvents._Ball_Is_Move -= HideStick;
        GameEvents._Ball_Is_Stopped -= ShowStick;
    }
}
