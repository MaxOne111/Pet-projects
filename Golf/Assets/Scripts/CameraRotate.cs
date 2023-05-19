using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private Transform _Camera_Anchor;
    [SerializeField] private float _Sensitivity = 100;

    private void Awake()
    {
        GameEvents._Ball_Is_Stopped += EnableCameraRotate;
    }

    private void Rotate()
    {
        float _mouse_X = Input.GetAxis("Mouse X") * _Sensitivity * Time.deltaTime;
        if (Input.GetMouseButton(1))
        {
            _Camera_Anchor.transform.Rotate(Vector3.up * _mouse_X);
        }
    }

    public void EnableCameraRotate()
    {
        enabled = true;
    }
    
    public void DisableCameraRotate()
    {
        enabled = false;
    }

    private void Update()
    {
        Rotate();
    }

    private void OnDestroy()
    {
        GameEvents._Ball_Is_Stopped -= EnableCameraRotate;
    }
}
