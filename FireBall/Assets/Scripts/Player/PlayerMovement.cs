using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _Dropdown;
    [SerializeField] private Joystick _joystick;
    
    [SerializeField] private float _Move_Speed;
    private float _Y_Offset = 0.4f;

    [SerializeField] private float _Border_X;
    [SerializeField] private float _Border_Z;

    private delegate void Controller();
    private Controller _Controller;
    
    private Ray _Move_Direction;
    private RaycastHit _Move_Point;
    private Vector3 _End_Position;

    private Rigidbody _rb;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _Controller = JoystickControls;
    }

    private void Update()
    {
        _Controller();
    }

    public void SelectMovementMode()
    {
        switch (_Dropdown.value)
        {
            case 0: _Controller = JoystickControls;
                _joystick.enabled = true;
                _Move_Speed = 20f;
                break;
            case 1: _Controller = FingerControls;
                _joystick.enabled = false;
                _Move_Speed = 7;
                break;
        }
    }
    
    private Vector3 EndPosition()
    {
        if (Input.GetMouseButton(0))
        {
            _Move_Direction = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_Move_Direction, out _Move_Point, 100))
            {
                if (_Move_Point.collider.CompareTag("Walkable"))
                    _End_Position = new Vector3(_Move_Point.point.x, _Move_Point.point.y + _Y_Offset, _Move_Point.point.z);
            }
        }
        return _End_Position;
    }
    
    private void FingerControls()
    {
        transform.position = Vector3.Lerp(transform.position, EndPosition(), _Move_Speed * Time.deltaTime);
    }

    private void JoystickControls()
    {
        Borders();
        
        _End_Position = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
        transform.Translate(_End_Position * _Move_Speed * Time.deltaTime);
        
    }

    private void Borders()
    {
        if (transform.position.x >= _Border_X)
        {
            transform.position = new Vector3(_Border_X, transform.position.y, transform.position.z);
        }
        else if(transform.position.x <= -_Border_X)
        {
            transform.position = new Vector3(-_Border_X, transform.position.y, transform.position.z);
        }
        
        if (transform.position.z >= _Border_Z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _Border_Z);
        }
        else if(transform.position.z <= -_Border_Z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -_Border_Z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            float _border = transform.position.x;
            if (transform.position.x >= _border)
            {
                transform.position = new Vector3(_border, transform.position.y, transform.position.z);
            }
        }
    }
}
